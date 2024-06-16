namespace CarRental.Domain.Contracts
{
    public interface IRentalUnitOfWork : IDisposable
    {
        IAutoPartRepository AutoPartRepository { get; }
        ICarRepository CarRepository { get; }
        IContractorRepository ContractorRepository { get; }
        IOrderRepository OrderRepository { get; }  
        IPersonelRepository PersonelRepository { get; }
        IServiceRepository ServiceRepository { get; }
        void Commit();
    }
}