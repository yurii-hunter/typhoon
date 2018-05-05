using System.Collections.Generic;
using System.Linq;

namespace Typhoon.Tools
{
    internal static class Extensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> value)
        {
            return value == null || !value.Any();
        }
    }
}
