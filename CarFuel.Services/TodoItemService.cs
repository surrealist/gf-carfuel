using CarFuel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFuel.Data;

namespace CarFuel.Services {
  public class TodoItemService : ServiceBase<TodoItem>, ITodoItemService {

    private readonly IUserService userService;

    public TodoItemService(IRepository<TodoItem> baseRepo, IUserService userService) : base(baseRepo) {
      this.userService = userService;
    }

    public override TodoItem Find(params object[] keys) {
      int id = (int)keys[0];
      return Query(x => x.Id == id)
        .SingleOrDefault();
    }

    public override IQueryable<TodoItem> Query(Func<TodoItem, bool> criteria) {
      return base.Query(criteria)
                 .Where(item => item.OwnerId == userService.CurrentUserId())
                 .AsQueryable();
    }


    public override TodoItem Add(TodoItem item) {
      if (Query(c =>!c.IsDone).Count() >=5) {
        throw new Exception("Please complete items before add a new one.");
      }

      item.OwnerId = userService.CurrentUserId();
      return base.Add(item);
    }

    public void MarkAsComplete(int id) {
      var item = Find(id);
      item.MarkAsComplete();
      SaveChanges();
    }

    public void CancelComplete(int id) {
      var item = Find(id);
      item.CancelComplete();
      SaveChanges();
    }
  }
}
