﻿using CarRental.Domain.Contracts;

namespace CarRental.Infrastructure
{
    public class RentalUnitOfWork : IRentalUnitOfWork
    {
        private readonly RentalDbContext _context;
        public IAutoPartRepository AutoPartRepository { get; set; }
        public ICarRepository CarRepository { get; }
        public IContractorRepository ContractorRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public IPersonelRepository PersonelRepository { get; set; }
        public IServiceRepository ServiceRepository { get; set; }

        public RentalUnitOfWork(RentalDbContext context, 
                                IAutoPartRepository autoPartRepository, ICarRepository carRepository,
                                IContractorRepository contractorRepository, IOrderRepository orderRepository, 
                                IPersonelRepository personelRepository, IServiceRepository serviceRepository)
        {
            _context = context;
            AutoPartRepository = autoPartRepository;
            CarRepository = carRepository;
            ContractorRepository = contractorRepository;
            OrderRepository = orderRepository;
            PersonelRepository = personelRepository;
            ServiceRepository = serviceRepository;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}