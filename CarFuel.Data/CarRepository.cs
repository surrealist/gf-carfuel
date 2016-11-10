using CarFuel.Models;
using System.Data.Entity;

namespace CarFuel.Data {
  public class CarRepository : RepositoryBase<Car> {

    public CarRepository(DbContext context) : base(context) {
      // 
    }

  }
}
