using System;
using UnityEngine;
using Object = UnityEngine.Object;
namespace TCS.TestSystems.Logging
{
    public class Logger
    {
        public Type SystemType { get; }
        public volatile bool IsEnabled;
        Color m_logColor;

        readonly object m_lockObj = new();

        // Cached colored name
        string m_coloredName;

        public Logger(Type systemType, bool isEnabled, Color? logColor = null)
        {
            SystemType = systemType;
            IsEnabled = isEnabled;
            m_logColor = logColor ?? Color.white; // Default to white if no color is provided
            m_coloredName = $"[{SystemType.Name}]".RichColor(m_logColor);
        }

        public void SetLogColor(Color color)
        {
            lock (m_lockObj)
            {
                m_logColor = color;
                m_coloredName = $"[{SystemType.Name}]".RichColor(m_logColor);
            }
        }

        public void LogMessage(string message, Object context = null)
        {
            if (!ShouldLog()) return;

            var formattedMessage = string.Concat(m_coloredName, " ", message);
            Debug.Log(formattedMessage, context);

            GameLogger.AddLogEntry(new LogEntry
            {
                Timestamp = DateTime.Now,
                Type = LogType.Log,
                SystemName = SystemType.Name,
                Message = message
            });
        }

        public void LogWarningMessage(string message, Object context = null)
        {
            if (!ShouldLog()) return;

            var formattedMessage = string.Concat(m_coloredName, " ", message);
            Debug.LogWarning(formattedMessage, context);

            GameLogger.AddLogEntry(new LogEntry
            {
                Timestamp = DateTime.Now,
                Type = LogType.Warning,
                SystemName = SystemType.Name,
                Message = message
            });
        }

        public void LogErrorMessage(string message, Object context = null)
        {
            if (!ShouldLog()) return;

            var formattedMessage = string.Concat(m_coloredName, " ", message);
            Debug.LogError(formattedMessage, context);

            GameLogger.AddLogEntry(new LogEntry
            {
                Timestamp = DateTime.Now,
                Type = LogType.Error,
                SystemName = SystemType.Name,
                Message = message
            });
        }

        bool ShouldLog() => GameLogger.GlobalLoggingEnabled && IsEnabled;

        public Color GetLogColor()
        {
            lock (m_lockObj)
            {
                return m_logColor;
            }
        }
    }
}