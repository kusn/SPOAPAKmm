using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPOAPAKmmReceiver.Data
{
    public static class Extensions
    {
        public static IEnumerable<T> Traverse<T>(this IEnumerable<T> item, Func<T, IEnumerable<T>> childSelector)
        {
            var stack = new Stack<T>(item);
            //stack.Push(item);
            while (stack.Any())
            {
                var next = stack.Pop();
                yield return next;
                foreach (var child in childSelector(next))
                    stack.Push(child);
            }
        }
    }
}
