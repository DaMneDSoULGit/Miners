#region

using System;

#endregion

namespace MinerServer.Helpers
{
    public static class DebugHelper
    {
        public static void CheckTimeSpan(Action action, Action<TimeSpan> timespan)
        {
            DateTime start = DateTime.Now;
            action();
            timespan(DateTime.Now - start);
        }

        public static void FullGCCollect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}