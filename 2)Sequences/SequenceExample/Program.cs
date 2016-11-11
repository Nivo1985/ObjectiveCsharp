using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceExample
{
    class Program
    {
        private static IPainter FindCheapest(int area, IEnumerable<IPainter> painters)
        {
            return painters
                .Where(x => x.IsAvaliable)
                .WithMinimum(x => x.EstiamteValue(area));

        }

        static void Main(string[] args)
        {
        }
    }
}
