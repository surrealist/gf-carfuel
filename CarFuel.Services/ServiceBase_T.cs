using CarFuel.Data;
using System;
using System.Linq;

namespace CarFuel.Services {
  public abstract class ServiceBase<T> : IService<T> where T : class {

    private readonly IRepository<T> _BaseRepo;

    public ServiceBase(IRepository<T> baseRepo) {
      if (baseRepo == null) {
        throw new ArgumentNullException(nameof(baseRepo));
      }
      _BaseRepo = baseRepo;
    }

    public abstract T Find(params object[] keys);

    public virtual T Add(T item) {
      return _BaseRepo.Add(item);
    }

    public virtual IQueryable<T> All() => Query(_ => true);

    public virtual IQueryable<T> Query(Func<T, bool> criteria) => _BaseRepo.Query(criteria);

    public virtual T Remove(T item) => _BaseRepo.Remove(item);

    public virtual int SaveChanges() => _BaseRepo.SaveChanges();

  }
}
