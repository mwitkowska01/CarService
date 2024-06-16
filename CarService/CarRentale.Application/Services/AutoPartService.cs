using AutoMapper;
using CarRental.Application.IServices;
using CarRental.Domain.Contracts;
using CarRental.Domain.Models;
using CarRental.SharedKernel.Dto;

namespace CarRental.Application.Services
{
    public class AutoPartService : IAutoPartService
    {
        private readonly IRentalUnitOfWork _uow;
        private readonly IMapper _mapper;

        public AutoPartService(IRentalUnitOfWork unitOfWork, IMapper mapper)
        {
            this._uow = unitOfWork;
            this._mapper = mapper;
        }

        public int Create(AutoPartDto dto)
        {
            if (dto == null)
            {
                //throw new BadRequestException("Product is null");
            }

            var id = _uow.AutoPartRepository.GetMaxId() + 1;
            var car = _mapper.Map<AutoPart>(dto);
            car.Id = id;

            //_uow.ServiceRepository.Insert(car);
            _uow.Commit();

            return id;
        }

        public void Delete(int id)
        {
            var car = _uow.AutoPartRepository.Get(id);
            if (car == null)
            {
                //    throw new NotFoundException("Product not found");
            }

            _uow.AutoPartRepository.Delete(car);
            _uow.Commit();
        }

        public List<AutoPartDto> GetAll()
        {
            var cars = _uow.AutoPartRepository.GetAll();

            List<AutoPartDto> result = _mapper.Map<List<AutoPartDto>>(cars);
            return result;
        }
        public AutoPartDto GetById(int id)
        {
            if (id <= 0)
            {
                //throw new BadRequestException("Id is less than zero");
            }

            var car = _uow.AutoPartRepository.Get(id);
            if (car == null)
            {
                //throw new NotFoundException("Product not found");
            }

            var result = _mapper.Map<AutoPartDto>(car);
            return result;
        }

        public void Update(AutoPartDto dto)
        {
            if (dto == null)
            {
                //throw new BadRequestException("No car data");
            }

            var car = _uow.AutoPartRepository.Get(dto.Id);
            if (car == null)
            {
                // throw new NotFoundException("Product not found");
            }

            //car.LicensePlate = dto.LicensePlate;

            _uow.Commit();
        }
    }
}