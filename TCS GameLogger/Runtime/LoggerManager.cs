using System;
using UnityEngine;
namespace TCS.GameLogger {
    public static class LoggerManager {
        public static void EnableLogger<T>() {
            GameLogger.SetLoggingEnabled<T>(true);
            Debug.Log("Logger enabled for system: " + typeof(T).Name);
        }

        public static void DisableLogger<T>() {
            GameLogger.SetLoggingEnabled<T>(false);
            Debug.Log("Logger disabled for system: " + typeof(T).Name);
        }

        public static void EnableLoggers(params Type[] systemTypes) {
            foreach (var type in systemTypes) {
                GameLogger.SetLoggingEnabled(type, true);
                Debug.Log("Logger enabled for system: " + type.Name);
            }
        }

        public static void DisableLoggers(params Type[] systemTypes) {
            foreach (var type in systemTypes) {
                GameLogger.SetLoggingEnabled(type, false);
                Debug.Log("Logger disabled for system: " + type.Name);
            }
        }

        public static void EnableAllLoggers() {
            GameLogger.SetGlobalLogging(true);
            Debug.Log("All loggers have been enabled globally.");
        }

        public static void DisableAllLoggers() {
            GameLogger.SetGlobalLogging(false);
            Debug.Log("All loggers have been disabled globally.");
        }

        public static void SetLoggerColor<T>(Color color) {
            GameLogger.SetColor<T>(color);
            Debug.Log("Logger color set for system: " + typeof(T).Name + " to " + color);
        }

        public static void SetLoggerColor(Type systemType, Color color) {
            GameLogger.SetColor(systemType, color);
            Debug.Log("Logger color set for system: " + systemType.Name + " to " + color);
        }
    }
}