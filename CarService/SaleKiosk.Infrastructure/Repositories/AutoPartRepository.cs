using CarRental.Domain.Contracts;
using CarRental.Domain.Models;

namespace CarRental.Infrastructure.Repositories
{
    public class AutoPartRepository : Repository<AutoPart>, IAutoPartRepository
    {
        private readonly RentalDbContext _rentalDbContext;
        public AutoPartRepository(RentalDbContext context)
        : base(context)
        {
            _rentalDbContext = context;
        }

        public int GetMaxId()
        {
            return _rentalDbContext.AutoParts.Max(x => x.Id);
        }
    }
}
