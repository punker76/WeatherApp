using System.Threading.Tasks;
using Common.Models;

namespace Common
{
    public interface ILocationService
    {
        Task<Position> GetLocation();
    }
}