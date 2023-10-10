using System.Diagnostics;

namespace GomokuApp.Common.Logging
{
    public static class Log
    {
        public static void Initialize()
        {
            const string logDir = "../app_logs";

            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);

            Trace.Listeners.Add(new TextWriterTraceListener($"{logDir}/{DateTime.Now:yyy-MM-dd}.log"));
            Trace.AutoFlush = true;
        }

        public static void Error(Exception ex)
        {
            Trace.WriteLine(string.Empty);
            Trace.WriteLine("-----------------");
            Trace.WriteLine($"Time: {DateTime.Now:hh:mm:ss tt}");
            Trace.TraceError($"Exception thrown: {ex.GetType()}");
            Trace.TraceError($"Message: {ex.Message}");
            Trace.TraceError($"Stack Trace: {ex.StackTrace}");
        }

        public static void Info(string message)
        {
            Trace.WriteLine(string.Empty);
            Trace.WriteLine("-----------------");
            Trace.WriteLine($"Time: {DateTime.Now:hh:mm:ss tt}");
            Trace.TraceInformation(message);
        }
    }
}
