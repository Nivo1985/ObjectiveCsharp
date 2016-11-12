using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceExample
{
    class CompositePainter<TPainter>: IPainter
        where TPainter: IPainter
    {
        private IEnumerable<TPainter> Painters { get; }

        private Func<int, IEnumerable<TPainter>, IPainter> Reduce { get; }

        public CompositePainter(IEnumerable<TPainter> paintres, Func<int, IEnumerable<TPainter>, IPainter> reduce)
        {
            this.Painters = paintres.ToList();
            this.Reduce = reduce;
        }

        //private IPainter Reduce(int area)
        //{
        //    var time =
        //        TimeSpan.FromHours(1 / this.Painters
        //        .Where(x => x.IsAvaliable)
        //        .Select(x => 1 / x.EstimateTime(area).TotalHours)
        //        .Sum());

        //    var cost =
        //        this.Painters
        //            .Where(x => x.IsAvaliable)
        //            .Select(x => x.EstimateValue(area) / x.EstimateTime(area).TotalHours * time.TotalHours)
        //            .Sum();

        //    return new ProportionalPainter()
        //    {
        //        TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / area),
        //        DolarPerHour = cost / time.TotalHours
        //    };
        //}

        public bool IsAvaliable => this.Painters.Any(x =>x.IsAvaliable);
        public TimeSpan EstimateTime(int area) =>
            this.Reduce(area, this.Painters).EstimateTime(area);

        public double EstimateValue(int area) =>
            this.Reduce(area, this.Painters).EstimateValue(area);
    }
}
