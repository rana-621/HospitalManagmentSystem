using Hospital.Repositories.Interfaces;

namespace Hospital.Repositories.Implementation;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    private bool disposed = false;

    public void Dispose()
    {
        disposed = true;
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }

    public IGenericRepository<T> GenericRepository<T>() where T : class
    {
        IGenericRepository<T> repo = new GenericRepository<T>(_context);
        return repo;
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
