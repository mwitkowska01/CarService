using CarRental.Domain.Models;

namespace CarRental.Domain.Contracts
{
    public interface IAutoPartRepository : IRepository<AutoPart>
    {
        int GetMaxId();

    }
}
