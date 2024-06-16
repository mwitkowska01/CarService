using CarRental.Domain.Contracts;
using CarRental.Domain.Models;
using CarRental.SharedKernel.Dto;

namespace CarRental.Infrastructure.Repositories
{
    public class ContractorRepository : Repository<Contractor>, IContractorRepository
    {
        private readonly RentalDbContext _rentalDbContext;
        public ContractorRepository(RentalDbContext context)
        : base(context)
        {
            _rentalDbContext = context;
        }
        public int GetMaxId()
        {
            return _rentalDbContext.Contractors.Max(x => x.Id);
        }

        public List<Car> GetContractorCar(int id)
        {
            List<Car> carList = new List<Car>();

            carList = _rentalDbContext.Contractors
                 .Where(c => c.Id == id)
                 .SelectMany(c => c.Cars)
                 .ToList();


            var kk = _rentalDbContext.Contractors.ToList();


            return carList;
        }
    }
}