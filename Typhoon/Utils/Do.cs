using System;
using System.Threading;

namespace Typhoon.Tools
{
    internal static class Do
    {
        public static T Retry<T>(Func<T> action, int retryCount = 5, int retryInterval = 100)
        {
            var attempt = 0;
            var exception = new Exception();
            while (retryCount > attempt++)
            {
                try
                {
                    return action();
                }
                catch (Exception ex)
                {
                    Thread.Sleep(retryInterval);
                    exception = ex;
                }
            }
            throw exception;
        }

        public static void Retry(Action action, int retryCount = 5, int retryInterval = 100)
        {
            var attempt = 0;
            var exception = new Exception();
            while (retryCount > attempt++)
            {
                try
                {
                    action();
                    return;
                }
                catch (Exception ex)
                {
                    Thread.Sleep(retryInterval);
                    exception = ex;
                }
            }
            throw exception;
        }
    }
}
