using System.Collections.Generic;

namespace IOTEC_ACME.DaysNameSpace
{
    public interface IDays
    {
        List<string> GetlistDaysWeeks();
        List<string> GetlistDaysWeekEnds();
    }
}
