using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

public static void Run(TimerInfo myTimer, TraceWriter log)
{
    const int MB = 1024 * 1024;
    
    log.Verbose($"MemHoggingCSharp started at: {DateTime.Now}");    
    var size = 64 * MB;
    var ptrs = new List<IntPtr>();
    var end = DateTime.Now + TimeSpan.FromSeconds(40);
    while (DateTime.Now < end)
    {
        ptrs.Add(Marshal.AllocHGlobal(size));
    
        var process = Process.GetCurrentProcess();
        log.Verbose($"MemHoggingCSharp pid = {process.Id}, private = {process.PrivateMemorySize64/MB:N0}MB, virtual = {process.VirtualMemorySize64/MB:N0}MB");    
    
        Thread.Sleep(500);
    }
    log.Verbose($"MemHoggingCSharp done at: {DateTime.Now}");    
}