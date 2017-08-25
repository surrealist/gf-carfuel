using CarFuel.Models;
using CarFuel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarFuel.Web.Controllers {
  public class TodoController : Controller {
    private readonly IService<TodoItem> todoService;

    public TodoController(IService<TodoItem> todoService) {
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

        todoService.Add(item);
        todoService.SaveChanges();

        return RedirectToAction("Index");
      }
      return View(item);
    }

  }
}