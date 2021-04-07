using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Domain.Core.Extensions
{
    public static class IEnumerableExtensions
    {
        [DebuggerStepThrough]
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
        {
            if (list == null)
            {
                return true;
            }

            if (!list.Any())
            {
                return true;
            }

            return false;
        }
    }
}
