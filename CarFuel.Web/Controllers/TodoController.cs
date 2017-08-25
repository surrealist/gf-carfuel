using CarFuel.Models;
using CarFuel.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CarFuel.Web.Controllers {

  [Authorize]
  public class TodoController : Controller {

    private readonly ITodoItemService todoService;

    public TodoController(ITodoItemService todoService) {
      this.todoService = todoService;
    }

    public ActionResult Index() {

      var items = from item in todoService.All()
                  orderby item.IsDone
                  select item;

      return View(items.ToList());
    }

    public ActionResult Create() {
      return View();
    }

    [HttpPost]
    public ActionResult Create(TodoItem item) {
      if (ModelState.IsValid) {

        try {   
          todoService.Add(item);
          todoService.SaveChanges();
        }
        catch (Exception ex) {
          TempData["error"] = ex.Message;
        }

        return RedirectToAction("Index");
      }
      return View(item);
    }

    [HttpPost]
    public ActionResult MarkAsComplete(int id) {
      todoService.MarkAsComplete(id);
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult CancelComplete(int id) {
      todoService.CancelComplete(id);
      return RedirectToAction("Index");
    }


  }
}