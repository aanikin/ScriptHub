﻿using System;
using System.Diagnostics;

namespace ScriptHub
{
    public interface IScriptRunner
    {
        event EventHandler Done;
        event EventHandler ErrorReceived;
        event DataReceivedEventHandler OutputDataReceived;
        void RunScript();
        void Kill();
    }
}
