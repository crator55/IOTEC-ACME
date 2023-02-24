using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTEC_ACME
{
    internal interface IWorkingHours
    {
        TimeSpan GetStartNight();
        TimeSpan GetEndNight();
        TimeSpan GetStartNormal();
        TimeSpan GetEndNormal();
        TimeSpan GetStartExtra();
        TimeSpan GetEndExtra();
    }
}
