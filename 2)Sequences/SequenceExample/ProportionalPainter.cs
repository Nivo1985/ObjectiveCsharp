using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceExample
{
    class ProportionalPainter: IPainter
    {
        public TimeSpan TimePerSqMeter { get; set; }
        public double DolarPerHour { get; set; }

        public bool IsAvaliable => true;
        public TimeSpan EstimateTime(int area)=>
            TimeSpan.FromHours(this.TimePerSqMeter.TotalHours*area);

        public double EstimateValue(int area) =>
            this.EstimateTime(area).TotalHours*this.DolarPerHour;
    }
}
