﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace IOTEC_ACME
{
    public class Salary : Days,ISalary
    {
        private readonly Helper Helper= new Helper();
        public List<string> GetHourSalary()
        {
            try
            {
                var allData = GetDataFromFile(Helper.Path);
                List<string> result = new List<string>();
                if (allData.Length>=5)
                {
                    foreach (var item in allData)
                    {
                        var data = item.Split(',').ToList();
                        var name = GetNameFromFile(data[0]);
                        double totalSalary = 0;
                        foreach (string item3 in GetDataFormatedHours(data))
                        {
                            var day = GetDayOflabor(item3);
                            var isDayWeek = GetlistDaysWeeks().Contains(day);
                            totalSalary += GetSalaryDays(isDayWeek, GetStartTime(item3), GetEndTime(item3));
                        }
                        result.Add($"The amount to pay {name} is: {totalSalary} USD");
                    }
                    return result;
                }
                else
                {
                    result.Add(Helper.LessThan5);
                    return result;
                }
               
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        public string[] GetDataFromFile(string Path)
        {
            try
            {
                return File.ReadAllText(Path).Replace("\r", "").Split('\n');
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
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
            double salary = 0;
            TimeSpan elapsed;
            bool normalSalary = startTime >= GetStartNormal() && endTime <= GetEndNormal();
            bool extraSalary = startTime >= GetStartExtra() && endTime <= GetEndExtra();
            bool nightSalary = startTime >= GetStartNight() && endTime <= GetEndNight();
            bool morethanEight = (startTime >= GetStartNight() && startTime <= GetEndNight()) &&
                (endTime >= GetStartExtra() && endTime <= GetEndExtra());
            bool normalAndNight = (startTime >= GetStartNight() && startTime <= GetEndNight()) &&
                (endTime >= GetStartNormal() && endTime <= GetEndNormal());
            bool normalAndExtra = (startTime >= GetStartNormal() && startTime <= GetEndNormal()) &&
                (endTime >= GetStartExtra() && endTime <= GetEndExtra());
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
                elapsed = GetEndNight().Subtract(startTime);
                salary += elapsed.TotalHours * 25;
                elapsed = GetEndNormal().Subtract(GetStartNormal());
                salary += elapsed.TotalHours * 15;
                elapsed = GetEndExtra().Subtract(endTime);
                salary += elapsed.TotalHours * 20;
            }
            if (!isDayWeek && morethanEight)
            {
                elapsed = GetEndNight().Subtract(startTime);
                salary += elapsed.TotalHours * 30;
                elapsed = GetEndNormal().Subtract(GetStartNormal());
                salary += elapsed.TotalHours * 20;
                elapsed = GetEndExtra().Subtract(endTime);
                salary += elapsed.TotalHours * 25;
            }
            if (isDayWeek && normalAndNight)
            {
                elapsed = GetEndNight().Subtract(startTime);
                salary += elapsed.TotalHours * 25;
                elapsed = GetEndNormal().Subtract(endTime);
                salary += elapsed.TotalHours * 15;

            }
            if (!isDayWeek && normalAndNight)
            {
                elapsed = GetEndNight().Subtract(startTime);
                salary += elapsed.TotalHours * 30;
                elapsed = GetEndNormal().Subtract(endTime);
                salary += elapsed.TotalHours * 20;

            }
            if (isDayWeek && normalAndExtra)
            {
                elapsed = GetEndNormal().Subtract(startTime);
                salary += elapsed.TotalHours * 15;
                elapsed = GetEndExtra().Subtract(endTime);
                salary += elapsed.TotalHours * 20;
            }
            if (!isDayWeek && normalAndExtra)
            {
                elapsed = GetEndNormal().Subtract(startTime);
                salary += elapsed.TotalHours * 20;
                elapsed = GetEndExtra().Subtract(endTime);
                salary += elapsed.TotalHours * 15;
            }
            return Math.Round(salary,2);
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
