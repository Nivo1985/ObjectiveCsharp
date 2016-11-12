using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceExample
{
    static class CompositePainterFactories
    {
        public static  IPainter CreateCheapestSelector(IEnumerable<ProportionalPainter> painters) =>
            new CompositePainter<IPainter>(painters,
                (area, sequece) => new Painters(sequece).GetAvaliable().GetCheapestOne(area));

        public static IPainter CreateFastestSelector(IEnumerable<ProportionalPainter> painters) =>
            new CompositePainter<IPainter>(painters,
                (area, sequece) => new Painters(sequece).GetAvaliable().GetFastestOne(area));

        public static IPainter CreateGroup(IEnumerable<ProportionalPainter> painters) =>
            new CompositePainter<ProportionalPainter>(painters, (area, sequence) =>
            {
                var time =
                    TimeSpan.FromHours(1 / sequence
                    .Where(x => x.IsAvaliable)
                    .Select(x => 1 / x.EstimateTime(area).TotalHours)
                    .Sum());

                var cost =
                    sequence
                        .Where(x => x.IsAvaliable)
                        .Select(x => x.EstimateValue(area) / x.EstimateTime(area).TotalHours * time.TotalHours)
                        .Sum();

                return new ProportionalPainter()
                {
                    TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / area),
                    DolarPerHour = cost / time.TotalHours
                };
            });
    }
}
