namespace gh_signalr_demo.Models
{
    public class FarmDetails
    {
        public int Id { get; set; } 
        public string FarmName { get; set; } =string.Empty;
        public double FarmTemperature { get; set;} = double.MinValue;
    }
}
