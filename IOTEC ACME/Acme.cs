using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IOTEC_ACME
{
    public class Acme : IAcme
    {
        private Helper Helper { get; set; } = new Helper();


        public List<string> GetHourSalary()
        {

            string contents = File.ReadAllText(Helper.Path);
            var allData = contents.Replace("\r", "").Split('\n');
            List<string> result = new List<string>();
            foreach (var item in allData)
            {
                var data = item.Split(',').ToList();
                var name = GetNameFromFile(data[0]);
                double totalSalary = 0;
                Days days = new Days();
                foreach (string item3 in GetDataFormatedHours(data))
                {
                    var day = GetDayOflabor(item3);
                    var isDayWeek = days.GetlistDaysWeeks().Contains(day);
                    totalSalary += GetSalaryDays(isDayWeek, GetStartTime(item3), GetEndTime(item3));
                }
                result.Add($"The amount to pay {name} is: {totalSalary} USD");
            }
            return result;
        }
        private List<string> GetDataFormatedHours(List<string> Data)
        {
            List<string> dataFormatedHours = new List<string>();
            foreach (var item2 in Data.Select((value, i) => new { i, value }))
            {
                if (item2.i == 0)
                {
                    dataFormatedHours.Add(item2.value.Substring(item2.value.IndexOf('=') + 1));
                }
                else
                {
                    dataFormatedHours.Add(item2.value);
                }
            }
            return dataFormatedHours;
        }
        public double GetSalaryDays(bool isDayWeek, TimeSpan startTime, TimeSpan endTime)
        {
            WorkingHours workingHours = new WorkingHours();
            double salary = 0;
            TimeSpan elapsed;
            bool normalSalary = startTime >= workingHours.StartNormal && endTime <= workingHours.EndNormal;
            bool extraSalary = startTime >= workingHours.StartExtra && endTime <= workingHours.EndExtra;
            bool nightSalary = startTime >= workingHours.StartNight && endTime <= workingHours.EndNight;
            bool morethanEight = (startTime >= workingHours.StartNight && startTime <= workingHours.EndNight) &&
                (endTime >= workingHours.StartNormal && endTime <= workingHours.EndNormal);
            bool normalAndNight = (startTime >= workingHours.StartNight && startTime <= workingHours.EndNight) &&
                (endTime >= workingHours.StartNormal && endTime <= workingHours.EndNormal);
            bool normalAndExtra = (startTime >= workingHours.StartNormal && startTime <= workingHours.EndNormal) &&
                (endTime >= workingHours.StartExtra && endTime <= workingHours.StartExtra);
            if (isDayWeek && normalSalary)
            {
                elapsed = endTime.Subtract(startTime);
                salary += elapsed.TotalHours * 15;
            }
            if (!isDayWeek && normalSalary)
            {
                elapsed = endTime.Subtract(startTime);
                salary += elapsed.TotalHours * 20;
            }
            if (isDayWeek && extraSalary)
            {
                elapsed = endTime.Subtract(startTime);
                salary += elapsed.TotalHours * 20;
            }
            if (!isDayWeek && extraSalary)
            {
                elapsed = endTime.Subtract(startTime);
                salary += elapsed.TotalHours * 25;
            }
            if (isDayWeek && nightSalary)
            {
                elapsed = endTime.Subtract(startTime);
                salary += elapsed.TotalHours * 25;
            }
            if (!isDayWeek && nightSalary)
            {
                elapsed = endTime.Subtract(startTime);
                salary += elapsed.TotalHours * 30;
            }
            if (isDayWeek && morethanEight)
            {
                elapsed = workingHours.EndNight.Subtract(startTime);
                salary += elapsed.TotalHours * 25;
                elapsed = workingHours.EndNormal.Subtract(workingHours.StartNormal);
                salary += elapsed.TotalHours * 15;
                elapsed = workingHours.EndExtra.Subtract(endTime);
                salary += elapsed.TotalHours * 20;
            }
            if (!isDayWeek && morethanEight)
            {
                elapsed = workingHours.EndNight.Subtract(startTime);
                salary += elapsed.TotalHours * 30;
                elapsed = workingHours.EndNormal.Subtract(workingHours.StartNormal);
                salary += elapsed.TotalHours * 20;
                elapsed = workingHours.EndExtra.Subtract(endTime);
                salary += elapsed.TotalHours * 25;
            }
            if (isDayWeek && normalAndNight)
            {
                elapsed = workingHours.EndNight.Subtract(startTime);
                salary += elapsed.TotalHours * 25;
                elapsed = workingHours.EndNormal.Subtract(endTime);
                salary += elapsed.TotalHours * 15;

            }
            if (!isDayWeek && normalAndNight)
            {
                elapsed = workingHours.EndNight.Subtract(startTime);
                salary += elapsed.TotalHours * 30;
                elapsed = workingHours.EndNormal.Subtract(endTime);
                salary += elapsed.TotalHours * 20;

            }
            if (isDayWeek && normalAndExtra)
            {
                elapsed = workingHours.EndNormal.Subtract(startTime);
                salary += elapsed.TotalHours * 15;
                elapsed = workingHours.EndExtra.Subtract(endTime);
                salary += elapsed.TotalHours * 20;
            }
            if (!isDayWeek && normalAndExtra)
            {
                elapsed = workingHours.EndNormal.Subtract(startTime);
                salary += elapsed.TotalHours * 20;
                elapsed = workingHours.EndExtra.Subtract(endTime);
                salary += elapsed.TotalHours * 15;
            }
            return salary;
        }
        public string GetNameFromFile(string stringFile)
        {
            return stringFile.Substring(0, stringFile.IndexOf('='));
        }
        public string GetDayOflabor(string dayEntry)
        {
            return dayEntry.Substring(0, 2);
        }
        public TimeSpan GetStartTime(string time)
        {
            return TimeSpan.Parse(time.Substring(2, time.IndexOf('-') - 2));
        }
        public TimeSpan GetEndTime(string time)
        {
            return TimeSpan.Parse(time.Substring(time.IndexOf('-') + 1));
        }
    }
}
