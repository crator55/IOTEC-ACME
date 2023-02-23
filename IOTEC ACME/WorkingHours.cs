using System;

namespace IOTEC_ACME
{
    public class WorkingHours
    {
        public TimeSpan StartNight { get; set; } = new TimeSpan(0, 0, 0);
        public TimeSpan EndNight { get; set; } = new TimeSpan(9, 0, 0);
        public TimeSpan StartNormal { get; set; } = new TimeSpan(9, 0, 1);
        public TimeSpan EndNormal { get; set; } = new TimeSpan(18, 0, 0);
        public TimeSpan StartExtra { get; set; } = new TimeSpan(18, 0, 1);
        public TimeSpan EndExtra { get; set; } = new TimeSpan(23, 59, 59);
    }
}
