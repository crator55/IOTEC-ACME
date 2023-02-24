using System;
using IOTEC_ACME.DaysNameSpace;
namespace IOTEC_ACME
{
    public class WorkingHours:Days,IWorkingHours
    {
        #region Constans
        private TimeSpan StartNight { get; set; } 
        private TimeSpan EndNight { get; set; } 
        private TimeSpan StartNormal { get; set; } 
        private TimeSpan EndNormal { get; set; } 
        private TimeSpan StartExtra { get; set; }
        private TimeSpan EndExtra { get; set; }
        #endregion
        #region Constructor
        public WorkingHours ()
        {
            this.StartNight = new TimeSpan(0, 0, 0);
            this.EndNight =  new TimeSpan(9, 0, 0); ;
            this.StartNormal = new TimeSpan(9, 0, 1);
            this.EndNormal = new TimeSpan(18, 0, 0);
            this.StartExtra = new TimeSpan(18, 0, 1);
            this.EndExtra = new TimeSpan(23, 59, 59);
        }
        #endregion
        public TimeSpan GetStartNight()=> StartNight;
 
        public TimeSpan GetEndNight()=> EndNight;

        public TimeSpan GetStartNormal()=> StartNormal;
        public TimeSpan GetEndNormal() => EndNormal;
        public TimeSpan GetStartExtra()=> StartExtra;
        public TimeSpan GetEndExtra()=> EndExtra;
    }
}
