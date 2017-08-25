using CarFuel.Models;

namespace CarFuel.Services {
  public interface ITodoItemService : IService<TodoItem> {
    void MarkAsComplete(int id);
    void CancelComplete(int id);
  }
}
