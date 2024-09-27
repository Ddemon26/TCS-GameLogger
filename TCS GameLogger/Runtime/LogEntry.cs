﻿using System;
using UnityEngine;
namespace TCS.TestSystems.Logging
{
    public struct LogEntry
    {
        public DateTime Timestamp { get; set; }
        public LogType Type { get; set; }
        public string SystemName { get; set; }
        public string Message { get; set; }
    }
}