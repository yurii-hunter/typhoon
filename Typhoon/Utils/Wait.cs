using System;
using System.Diagnostics;
using System.Threading;

namespace Typhoon.Tools
{
    internal static class Wait
    {
        private const int RETRY_INTERVAL = 100;

        /// <summary>
        /// Waits for function completed
        /// </summary>
        /// <param name="predicate">Function</param>
        /// <param name="timeoutSec">Maximum time of executing</param>
        /// <returns></returns>
        public static bool For(Func<bool> predicate, int timeoutSec = 30)
        {
            var timer = Stopwatch.StartNew();
            var timeout = TimeSpan.FromSeconds(timeoutSec);
            while (timer.Elapsed <= timeout)
            {
                if (predicate())
                {
                    return true;
                }
                Thread.Sleep(RETRY_INTERVAL);
            }
            return false;
        }
    }
}
