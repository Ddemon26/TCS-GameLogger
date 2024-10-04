using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace TCS.GameLogger {
    public static class GameLogger {
        // Dictionary to hold Logger instances for each system, identified by Type
        static readonly Dictionary<Type, Logger> Loggers = new();

        // Central log storage
        static readonly List<LogEntry> LogEntries = new(MAX_LOG_ENTRIES);

        // Maximum number of logs to store to prevent memory issues
        const int MAX_LOG_ENTRIES = 100;

        // Global flag to enable or disable all logging
        public static volatile bool GlobalLoggingEnabled = true;

        // Flag to allow runtime toggling of logs in development and runtime builds
        // ReSharper disable once ConvertToConstant.Local
        static readonly bool AllowRuntimeToggling =
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            true;
#else
            false; // Set to true if you want to allow runtime toggling in runtime builds
#endif

        // Lock object for thread safety
        static readonly object LockObj = new();

        // Cached colored name for unknown logs
        static readonly string SUnknownColoredName = "[Unknown]".RichColor(Color.gray);

        public static void Log(string message, Object context = null) {
            var callerType = GetCallerType();
            if (callerType == null) {
                RegisterUnknownLogEntry(message, LogType.Log, context);
                return;
            }

            var logger = GetLogger(callerType);
            logger.LogMessage(message, context);
        }

        public static void LogWarning(string message, Object context = null) {
            var callerType = GetCallerType();
            if (callerType == null) {
                RegisterUnknownLogEntry(message, LogType.Warning, context);
                return;
            }

            var logger = GetLogger(callerType);
            logger.LogWarningMessage(message, context);
        }

        public static void LogError(string message, Object context = null) {
            var callerType = GetCallerType();
            if (callerType == null) {
                RegisterUnknownLogEntry(message, LogType.Error, context);
                return;
            }

            var logger = GetLogger(callerType);
            logger.LogErrorMessage(message, context);
        }

        public static void SetGlobalLogging(bool enabled) {
            if (!AllowRuntimeToggling) {
                Debug.LogWarning("Runtime toggling is disabled in this build.");
                return;
            }

            GlobalLoggingEnabled = enabled;
        }

        public static void SetLoggingEnabled<T>(bool enabled) {
            if (!AllowRuntimeToggling) {
                Debug.LogWarning("Runtime toggling is disabled in this build.");
                return;
            }

            var systemType = typeof(T);
            lock (LockObj) {
                if (Loggers.TryGetValue(systemType, out var logger)) {
                    logger.IsEnabled = enabled;
                }
                else {
                    Loggers.Add(systemType, new Logger(systemType, enabled));
                }
            }
        }

        public static void SetLoggingEnabled(Type systemType, bool enabled) {
            if (!AllowRuntimeToggling) {
                Debug.LogWarning("Runtime toggling is disabled in this build.");
                return;
            }

            lock (LockObj) {
                if (Loggers.TryGetValue(systemType, out var logger)) {
                    logger.IsEnabled = enabled;
                }
                else {
                    Loggers.Add(systemType, new Logger(systemType, enabled));
                }
            }
        }

        public static void SetColor<T>(Color color) {
            var systemType = typeof(T);
            lock (LockObj) {
                if (Loggers.TryGetValue(systemType, out var logger)) {
                    logger.SetLogColor(color);
                }
                else {
                    Loggers.Add(systemType, new Logger(systemType, true, color));
                }
            }
        }

        public static void SetColor(Type systemType, Color color) {
            lock (LockObj) {
                if (Loggers.TryGetValue(systemType, out var logger)) {
                    logger.SetLogColor(color);
                }
                else {
                    Loggers.Add(systemType, new Logger(systemType, true, color));
                }
            }
        }

        public static List<LogEntry> GetAllLogs() {
            lock (LockObj) {
                return new List<LogEntry>(LogEntries);
            }
        }

        public static List<LogEntry> GetLogsByType(LogType type) {
            lock (LockObj) {
                List<LogEntry> result = new();
                foreach (var t in LogEntries) {
                    if (t.Type == type) {
                        result.Add(t);
                    }
                }

                return result;
            }
        }

        public static void ClearLogs() {
            lock (LockObj) {
                LogEntries.Clear();
            }
        }

        public static Color GetColor<T>() {
            var systemType = typeof(T);
            lock (LockObj) {
                return Loggers.TryGetValue(systemType, out var logger)
                    ? logger.GetLogColor()
                    : Color.white;
            }
        }

        public static Color GetColor(string systemName) {
            lock (LockObj) {
                // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
                foreach (var logger in Loggers.Values) {
                    if (logger.SystemType.Name.Equals(systemName, StringComparison.OrdinalIgnoreCase)) {
                        return logger.GetLogColor();
                    }
                }

                return Color.white;
            }
        }

        internal static void AddLogEntry(LogEntry entry) {
            lock (LockObj) {
                if (LogEntries.Count >= MAX_LOG_ENTRIES) {
                    LogEntries.RemoveAt(0); // Remove the oldest log to maintain the max size
                }

                LogEntries.Add(entry);
            }
        }

        static void RegisterUnknownLogEntry(string message, LogType type, Object context = null) {
            string formattedMessage = string.Concat(SUnknownColoredName, " ", message);

            switch (type) {
                case LogType.Warning:
                    Debug.LogWarning(formattedMessage, context);
                    break;
                case LogType.Error:
                    Debug.LogError(formattedMessage, context);
                    break;
                case LogType.Assert:
                    Debug.LogAssertion(formattedMessage, context);
                    break;
                case LogType.Log:
                    Debug.Log(formattedMessage, context);
                    break;
                case LogType.Exception:
                    Debug.LogException(new Exception(message), context);
                    break;
                default:
                    Debug.Log(formattedMessage, context);
                    break;
            }

            AddLogEntry
            (
                new LogEntry {
                    Timestamp = DateTime.Now,
                    Type = type,
                    SystemName = "Unknown",
                    Message = message
                }
            );
        }

        static Logger GetLogger(Type systemType) {
            lock (LockObj) {
                if (Loggers.TryGetValue(systemType, out var logger)) return logger;
                logger = new Logger(systemType, true);
                Loggers.Add(systemType, logger);

                return logger;
            }
        }

        static Type GetCallerType() {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            try {
                var stackTrace = new StackTrace();
                // Iterate through the stack frames to find the first method outside GameLogger
                for (var i = 2; i < stackTrace.FrameCount; i++) {
                    var method = stackTrace.GetFrame(i).GetMethod();
                    var declaringType = method.DeclaringType;
                    if (declaringType != typeof(GameLogger)) {
                        return declaringType;
                    }
                }
            }
            catch (Exception ex) {
                Debug.LogError("GameLogger: Failed to get caller type. Exception: " + ex.Message);
            }
#endif
            return null;
        }
    }
}