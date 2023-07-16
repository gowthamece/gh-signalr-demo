using gh_signalr_demo.Models;

namespace gh_signalr_demo.Repositories
{
    public interface IFarmTempRepo
    {
        IEnumerable<FarmDetails> GetAll();
        void NewTemperature(int farmId, int farmTemp);
    }
}
