using CarFuel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFuel.Data;

namespace CarFuel.Services {
  public class CarService : ServiceBase<Car> {

    public CarService(IRepository<Car> baseRepo) : base(baseRepo) {
      //
    }

    public override Car Find(params object[] keys) {
      Guid id = (Guid)keys[0];
      return Query(x => x.Id == id)
        .SingleOrDefault();
    } 

    public override Car Add(Car item) {
      if (All().Any(c => c.PlateNo == item.PlateNo)) {
        throw new Exception("Cannot duplicate car's plate number.");
      }

      return base.Add(item);
    }

  }

}
