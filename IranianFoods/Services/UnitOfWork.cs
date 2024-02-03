using IranianFoods.Data;

namespace IranianFoods.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context { get; set; }
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            Foods = new FoodRepository(_context);
        }
        public IFoodRepository Foods { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public Task CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
