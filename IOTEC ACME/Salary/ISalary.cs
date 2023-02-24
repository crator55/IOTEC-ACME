using System;
using System.Collections.Generic;

namespace IOTEC_ACME
{
    public interface ISalary
    {
        List<string> GetHourSalary();
        string[] GetDataFromFile(string Path);
        double GetSalaryDays(bool isDayWeek, TimeSpan startTime, TimeSpan endTime);
        string GetNameFromFile(string stringFile);
        string GetDayOflabor(string dayEntry);
        TimeSpan GetStartTime(string time);
        TimeSpan GetEndTime(string time);
    }
}
