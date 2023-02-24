namespace IOTEC_ACME.RatesNameSpace
{
    public class Rates:WorkingHours,IRates
    {
        private int NightWeekDay { get; set; }
        private int NormalWeekDay { get; set; }
        private int ExtraWeekDay { get; set; }
        private int NightWeekendDay { get; set; }
        private int NormalWeekendDay { get; set; }
        private int ExtraWeekendDay { get; set; }
        public Rates()
        {
            this.NightWeekDay= 25;
            this.NormalWeekDay = 15;
            this.ExtraWeekDay = 20;

            this.NightWeekendDay = 30;
            this.NormalWeekendDay = 20;
            this.ExtraWeekendDay= 25;               
        }

        public int GetNightWeekDayRate() => this.NightWeekDay;
        public int GetNormalWeekDayRate() => this.NormalWeekDay;
        public int GetExtraWeekDayRate() => this.ExtraWeekDay;
        public int GetNightWeekendDayRate() => this.NightWeekendDay;
        public int GetExtraWeekendDayRate() => this.ExtraWeekendDay;
        public int GetNormalWeekendDayRate() => this.NormalWeekendDay;


    }
}
