namespace IranianFoods.Services
{
    public interface IUnitOfWork:IDisposable
    {
        public IFoodRepository Foods { get; }
        public int Complete();
        public Task CompleteAsync();
    }
}
