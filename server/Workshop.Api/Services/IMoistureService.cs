using System.Threading.Tasks;

namespace Workshop.Api.Services
{
    public interface IMoistureService
    {
        Task<int> GetRawMoisture();
    }
}