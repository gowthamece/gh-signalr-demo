using gh_signalr_demo.Models;

namespace gh_signalr_demo.Repositories
{
    public class FarmMemoryRepo : IFarmTempRepo
    {
        private readonly List<FarmDetails> farms = new List<FarmDetails>();

        public FarmMemoryRepo()
        {
            farms.Add(new FarmDetails { Id=1, FarmName = "Farm A", FarmTemperature = 23 });
            farms.Add(new FarmDetails { Id=2, FarmName = "Farm B", FarmTemperature = 26 });
            farms.Add(new FarmDetails { Id=3, FarmName = "Farm B", FarmTemperature = 21 });
        }

        public IEnumerable<FarmDetails> GetAll()
        {
            return farms;
        }

        public void NewTemperature(int farmId, int farmTemp)
        {
            var auction = farms.Single(a => a.Id == farmId);
            auction.FarmTemperature = farmTemp;
        }
    }
}
