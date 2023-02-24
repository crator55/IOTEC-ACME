using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTEC_ACME
{
    public interface IDays
    {
        List<string> GetlistDaysWeeks();
        List<string> GetlistDaysWeekEnds();
    }
}
