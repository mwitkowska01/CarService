using CarRental.SharedKernel.Dto;

namespace CarRental.Application.IServices
{
    public interface IAutoPartService
    {
        List<AutoPartDto> GetAll();
        AutoPartDto GetById(int id);
        int Create(AutoPartDto dto);
        void Update(AutoPartDto dto);
        void Delete(int id);
    }
}