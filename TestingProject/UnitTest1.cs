using IOTEC_ACME;
using Newtonsoft.Json.Linq;

namespace TestingProject
{
    public class UnitTest1
    {
        [Fact]
        public void GetHourSalary()
        {
            Salary acme = new();
           var response= acme.GetHourSalary();
            Assert.Equal("The amount to pay ASTRID is: 85 USD", response.FirstOrDefault());

        }

        [Fact]
        public void GetSalaryDays()
        {
            Salary acme = new();
            var response = acme.GetSalaryDays(true,TimeSpan.Parse("10:00"),TimeSpan.Parse("12:00"));
            Assert.Equal(30, response);

        }
        [Fact]
        public void GetNameFromFile()
        {
            Salary acme = new();
            var response = acme.GetNameFromFile("ASTRID=MO10:00-12:00");
            Assert.Equal("ASTRID", response);

        }
        [Fact]
        public void GetDayOflabor()
        {
            Salary acme = new();
            var response = acme.GetDayOflabor("MO10:00-12:00");
            Assert.Equal("MO", response);

        }
        [Fact]
        public void GetStartTime()
        {
            Salary acme = new();
            var response = acme.GetStartTime("MO10:00-12:00");
            Assert.Equal(TimeSpan.Parse("10:00"), response);

        }
        [Fact]
        public void GetEndTime()
        {
            Salary acme = new();
            var response = acme.GetEndTime("MO10:00-12:00");
            Assert.Equal(TimeSpan.Parse("12:00"), response);

        }
        [Fact]
        public void GetDataFromFile()
        {
            Salary acme = new();
            var response = acme.GetDataFromFile(Helper.Path);
            Assert.NotEqual(string.Empty, response);

        }
    }
}