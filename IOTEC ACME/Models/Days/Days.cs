using System.Collections.Generic;
namespace IOTEC_ACME.DaysNameSpace
{
    public class Days : IDays
    {
        public List<string> GetlistDaysWeeks()
        {
            List<string> listDaysWeeks = new List<string>()
            {
                "MO",
                "TU",
                "WE",
                "TH",
                "FR"
            };
            return listDaysWeeks;
        }
        public List<string> GetlistDaysWeekEnds()
        {
            List<string> listDWeekEnds = new List<string>()
            {
                "SA",
                "SU"
            };
            return listDWeekEnds;
        }
    }
}
