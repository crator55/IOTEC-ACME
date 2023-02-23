using IOTEC_ACME;
using Newtonsoft.Json.Linq;

namespace TestingProject
{
    public class UnitTest1
    {

        private readonly IAcme _repository;
        private Helper Path;
        //public UnitTest1(IAcme repository)
        //{
        //    this._repository = repository;
        //}

        [Fact]
        public void GetHourSalary()
        {
            Acme acme = new();
           var response= acme.GetHourSalary();

            Assert.Equal("", response.FirstOrDefault());

        }
    }
}