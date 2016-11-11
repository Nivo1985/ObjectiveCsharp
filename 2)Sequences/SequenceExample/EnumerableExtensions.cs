using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceExample
{
    public static class EnumerableExtensions
    {
        public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterias)
            where T : class
            where TKey : IComparable<TKey> =>
                sequence
                    .Select(x=> Tuple.Create(x, criterias(x)))
            .Aggregate((Tuple<T,TKey>) null, (best, cur) =>
                    best == null || cur.Item2.CompareTo(best.Item2) < 0 ? cur : best)
            .Item1;
    }
}
