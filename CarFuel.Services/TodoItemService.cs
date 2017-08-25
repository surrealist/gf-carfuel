using CarFuel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFuel.Data;

namespace CarFuel.Services {
  public class TodoItemService : ServiceBase<TodoItem> {

    public TodoItemService(IRepository<TodoItem> baseRepo) : base(baseRepo) {
    }

    public override TodoItem Find(params object[] keys) {
      int id = (int)keys[0];
      return Query(x => x.Id == id)
        .SingleOrDefault();
    }

    public override TodoItem Add(TodoItem item) {
      if (Query(c =>!c.IsDone).Count() >=5) {
        throw new Exception("Please complete items before add a new one.");
      }

      return base.Add(item);
    }

  }
}
