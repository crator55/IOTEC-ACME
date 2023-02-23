using IOTEC_ACME;

namespace TestingProject
{
    public class UnitTest1
    {
        [Fact]
        public void GetHourSalary_String_First_Empoyee_ReturnsString()
        {
            Salary acme = new();
            var response = acme.GetHourSalary();
            Assert.Equal("The amount to pay ASTRID is: 85 USD", response.FirstOrDefault());
        }

        [Fact]
        public void GetHourSalary_Second_Empoyee_ReturnsString()
        {
            Salary acme = new();
            var response = acme.GetHourSalary();
            Assert.Equal("The amount to pay RENE is: 215 USD", response[1]);
        }

        [Fact]
        public void GetSalaryDays_NormalHour_WeekDay_ReturnsTimeSpan()
        {
            Salary acme = new();
            var response = acme.GetSalaryDays(true, TimeSpan.Parse("10:00"), TimeSpan.Parse("12:00"));
            Assert.Equal(30, response);
        }

        [Fact]
        public void GetSalaryDays_NormalHour_WeekendDay_ReturnsTimeSpan()
        {
            Salary acme = new();
            var response = acme.GetSalaryDays(false, TimeSpan.Parse("10:00"), TimeSpan.Parse("12:00"));
            Assert.Equal(40, response);
        }

        [Fact]
        public void GetSalaryDays_ExtraHour_WeekDay_ReturnsTimeSpan()
        {
            Salary acme = new();
            var response = acme.GetSalaryDays(true, TimeSpan.Parse("18:30"), TimeSpan.Parse("23:00"));
            Assert.Equal(90, response);
        }

        [Fact]
        public void GetSalaryDays_ExtraHour_WeekendDa_ReturnsTimeSpan()
        {
            Salary acme = new();
            var response = acme.GetSalaryDays(false, TimeSpan.Parse("18:30"), TimeSpan.Parse("23:00"));
            Assert.Equal(112.5, response);
        }

        [Fact]
        public void GetSalaryDays_NightHour_WeekDay_ReturnsTimeSpan()
        {
            Salary acme = new();
            var response = acme.GetSalaryDays(true, TimeSpan.Parse("00:00"), TimeSpan.Parse("8:00"));
            Assert.Equal(200, response);
        }

        [Fact]
        public void GetSalaryDays_NightHour_WeekendDa_ReturnsTimeSpan()
        {
            Salary acme = new();
            var response = acme.GetSalaryDays(false, TimeSpan.Parse("00:00"), TimeSpan.Parse("8:00"));
            Assert.Equal(240, response);
        }

        [Fact]
        public void GetSalaryDays_MoreEightHours_WeekDay_ReturnsTimeSpan()
        {
            Salary acme = new();
            var response = acme.GetSalaryDays(true, TimeSpan.Parse("00:00"), TimeSpan.Parse("23:00"));
            Assert.Equal(379.99, response);
        }

        [Fact]
        public void GetSalaryDays_MoreEightHours_WeekendDa_ReturnsTimeSpan()
        {
            Salary acme = new();
            var response = acme.GetSalaryDays(false, TimeSpan.Parse("00:00"), TimeSpan.Parse("23:00"));
            Assert.Equal(474.99, response);
        }

        [Fact]
        public void GetSalaryDays_NormalAndExtra_WeekDay_ReturnsTimeSpan()
        {
            Salary acme = new();
            var response = acme.GetSalaryDays(true, TimeSpan.Parse("10:00"), TimeSpan.Parse("23:00"));
            Assert.Equal(139.99, response);
        }

        [Fact]
        public void GetSalaryDays_NormalAndExtra_WeekendDa_ReturnsTimeSpan()
        {
            Salary acme = new();
            var response = acme.GetSalaryDays(false, TimeSpan.Parse("10:00"), TimeSpan.Parse("23:00"));
            Assert.Equal(175, response);
        }

        [Fact]
        public void GetSalaryDays_NormalAndNight_WeekDay_ReturnsTimeSpan()
        {
            Salary acme = new();
            var response = acme.GetSalaryDays(true, TimeSpan.Parse("00:00"), TimeSpan.Parse("14:00"));
            Assert.Equal(285, response);
        }

        [Fact]
        public void GetSalaryDays_NormalAndNight_WeekendDay_ReturnsTimeSpan()
        {
            Salary acme = new();
            var response = acme.GetSalaryDays(false, TimeSpan.Parse("00:00"), TimeSpan.Parse("14:00"));
            Assert.Equal(350, response);
        }

        [Fact]
        public void GetNameFromFile_Name_ReturnString()
        {
            Salary acme = new();
            var response = acme.GetNameFromFile("ASTRID=MO10:00-12:00");
            Assert.Equal("ASTRID", response);
        }

        [Fact]
        public void GetDayOflabor_Monday_ReturnString()
        {
            Salary acme = new();
            var response = acme.GetDayOflabor("MO10:00-12:00");
            Assert.Equal("MO", response);
        }

        [Fact]
        public void GetStartTime_10AM_ReturnTimeSpan()
        {
            Salary acme = new();
            var response = acme.GetStartTime("MO10:00-12:00");
            Assert.Equal(TimeSpan.Parse("10:00"), response);
        }

        [Fact]
        public void GetEndTime_12PM_ReturnTimeSpan()
        {
            Salary acme = new();
            var response = acme.GetEndTime("MO10:00-12:00");
            Assert.Equal(TimeSpan.Parse("12:00"), response);
        }

        [Fact]
        public void GetDataFromFile_GetData_ReturnString()
        {
            Salary acme = new();
            var response = acme.GetDataFromFile(Helper.Path);
            Assert.NotEqual(string.Empty, response);
        }
    }
}