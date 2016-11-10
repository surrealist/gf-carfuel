using System;
using System.Data.Entity;
using System.Linq;

namespace CarFuel.Data {
  public class RepositoryBase<T> : IRepository<T> where T : class {

    private readonly DbContext _context;

    public RepositoryBase(DbContext context) {
      _context = context;
    }

    public T Add(T item) {
      return _context.Set<T>().Add(item);
    }

    public IQueryable<T> Query(Func<T, bool> criteria) {
      return _context.Set<T>().Where(criteria).AsQueryable();
    }

    public IQueryable<T> All() {
      return _context.Set<T>().AsQueryable();
    }

    public T Remove(T item) {
      return _context.Set<T>().Remove(item);
    }

    public int SaveChanges() {
      return _context.SaveChanges();
    }
  }
}
