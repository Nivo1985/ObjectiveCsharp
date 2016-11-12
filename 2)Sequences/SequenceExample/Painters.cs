using System.Collections.Generic;
using System.Linq;

namespace SequenceExample
{
    public class Painters
    {
        private IEnumerable<IPainter> ContainedPainters { get; }

        public Painters(IEnumerable<IPainter> painters)
        {
            this.ContainedPainters = painters.ToList();
        }

        public Painters GetAvaliable() =>
            new Painters(this.ContainedPainters.Where(x=>x.IsAvaliable));

        public IPainter GetCheapestOne(int area) =>
            this.ContainedPainters.WithMinimum(x => x.EstimateValue(area));

        public IPainter GetFastestOne(int area) =>
            this.ContainedPainters.WithMinimum(x => x.EstimateTime(area));
    }
}