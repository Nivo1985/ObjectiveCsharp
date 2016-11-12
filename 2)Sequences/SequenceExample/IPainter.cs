using System;

namespace SequenceExample
{
    public interface IPainter
    {
        bool IsAvaliable { get; }
        TimeSpan EstimateTime(int area);
        double EstimateValue(int area);
    }
}