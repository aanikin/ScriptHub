﻿using System;
using System.Diagnostics;

namespace ScriptHub.Model
{
    public class ScriptHubDataReceivedEventArgs : EventArgs
    {
        public string Data { get; set; }
        public ScriptHubDataReceivedEventArgs(string data)
        {
            Data = data;
        }
        public ScriptHubDataReceivedEventArgs(DataReceivedEventArgs Source)
        {
            Data = Source.Data;
        }
    }
}
