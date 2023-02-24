using System;

namespace IOTEC_ACME
{
    public class WorkingHours:IWorkingHours
    {
        private TimeSpan StartNight { get; set; } 
        private TimeSpan EndNight { get; set; } 
        private TimeSpan StartNormal { get; set; } 
        private TimeSpan EndNormal { get; set; } 
        private TimeSpan StartExtra { get; set; }
        private TimeSpan EndExtra { get; set; } 
        public WorkingHours ()
        {
            this.StartNight = new TimeSpan(0, 0, 0);
            this.EndNight =  new TimeSpan(9, 0, 0); ;
            this.StartNormal = new TimeSpan(9, 0, 1);
            this.EndNormal = new TimeSpan(18, 0, 0);
            this.StartExtra = new TimeSpan(18, 0, 1);
            this.EndExtra = new TimeSpan(23, 59, 59);
        }
        public TimeSpan GetStartNight()
        {
            return StartNight;
        }
        public TimeSpan GetEndNight()
        {
            return EndNight;
        }
        public TimeSpan GetStartNormal()
        {
            return StartNormal;
        }
        public TimeSpan GetEndNormal()
        {
            return EndNormal;
        }
        public TimeSpan GetStartExtra()
        {
            return StartExtra;
        }
        public TimeSpan GetEndExtra()
        {
            return EndExtra;
        }

    }
}
