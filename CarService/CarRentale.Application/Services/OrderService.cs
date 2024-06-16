﻿using AutoMapper;
using CarRental.Application.IServices;
using CarRental.Domain.Contracts;
using CarRental.Domain.Models;
using CarRental.SharedKernel.Dto;

namespace SaleKiosk.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRentalUnitOfWork _uow;
        private readonly IMapper _mapper;

        public OrderService(IRentalUnitOfWork unitOfWork, IMapper mapper)
        {
            this._uow = unitOfWork;
            this._mapper = mapper;
        }

        public int Create(OrderDto dto)
        {
            if (dto == null)
            {
               // throw new BadRequestException("Order is null");
            }

            var id = _uow.OrderRepository.GetMaxId() + 1;
            var order = _mapper.Map<Order>(dto);
            order.Id = id;

            _uow.OrderRepository.Insert(order);
            _uow.Commit();

            return id;
        }

        public void Delete(int id)
        {
            var car = _uow.OrderRepository.Get(id);
            if (car == null)
            {
                //    throw new NotFoundException("Product not found");
            }

            _uow.OrderRepository.Delete(car);
            _uow.Commit();
        }

        public List<OrderDto> GetAll()
        {
            var orders = _uow.OrderRepository.GetAll();

            List<OrderDto> result = _mapper.Map<List<OrderDto>>(orders);
            return result;
        }

        public OrderDto GetByIdWithDetails(int id)
        {
            if (id <= 0)
            {
                //throw new BadRequestException("Id is less than zero");
            }

            var order = _uow.OrderRepository.GetByIdWithDetails(id);
            if (order == null)
            {
                //throw new NotFoundException("Order not found");
            }

            var result = _mapper.Map<OrderDto>(order);
            return result;
        }

        public OrderDto GetById(int id)
        {
            if (id <= 0)
            {
                //throw new BadRequestException("Id is less than zero");
            }

            var car = _uow.CarRepository.Get(id);
            if (car == null)
            {
                //throw new NotFoundException("Product not found");
            }

            var result = _mapper.Map<OrderDto>(car);
            return result;
        }

        public void Update(OrderDto dto)
        {
            if (dto == null)
            {
                //throw new BadRequestException("No car data");
            }

            var car = _uow.OrderRepository.Get(dto.Id);
            if (car == null)
            {
                // throw new NotFoundException("Product not found");
            }

            //car.LicensePlate = dto.LicensePlate;

            _uow.Commit();
        }
    }
}

