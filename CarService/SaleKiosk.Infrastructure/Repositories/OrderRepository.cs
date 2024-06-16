using CarRental.Domain.Contracts;
using CarRental.Domain.Models;
using CarRental.SharedKernel.Dto;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly RentalDbContext _rentalDbContext;
        public OrderRepository(RentalDbContext context)
        : base(context)
        {
            _rentalDbContext = context;
        }
        public int GetMaxId()
        {
            return _rentalDbContext.Orders.Max(x => x.Id);
        }

        public Order GetByIdWithDetails(int id)
        {
            var order = _rentalDbContext.Orders
                .Include(o => o.Details)
                .Where(o => o.Id == id)
                .FirstOrDefault();

            return order;
        }
    }
}