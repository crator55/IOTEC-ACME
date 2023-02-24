namespace IOTEC_ACME
{
    public class Helper
    {

        public  string Path { get; set; } 
        public  string LessThan5 { get; set; } 

        public Helper()
        {
            this.Path = "C:\\Users\\rapto\\Documents\\ACME-FILE.txt";
            this.LessThan5 = "It must be more than 5 records.";
        }
    }
}
