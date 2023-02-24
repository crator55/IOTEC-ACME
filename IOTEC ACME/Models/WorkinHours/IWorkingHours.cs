using System;

namespace IOTEC_ACME.WorkingHoursNameSpace
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
