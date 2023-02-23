using System;
using System.Collections.Generic;

namespace IOTEC_ACME
{
    public class Days:IDays
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
