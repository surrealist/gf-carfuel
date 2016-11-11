using CarFuel.Models;
using CarFuel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarFuel.Web.Controllers {

  public class CarsController : Controller {

    private readonly IService<Car> _carService;

    public CarsController(IService<Car> carService) {
      _carService = carService;
    }

    [Authorize]
    public ActionResult Index() {
      //CreateTestCar();

      var cars = _carService.All();
      return View(cars);
    }

    [Authorize]
    public ActionResult Add() {
      return View();
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Add(Car item) {
      if (ModelState.IsValid) {
        try {
          _carService.Add(item);
          _carService.SaveChanges(); 
          return RedirectToAction("Index");
        }
        catch (Exception ex) {
          ViewBag.Error = ex.Message; 
        } 
      }
      return View(item);
    }

    private void CreateTestCar() {
      var c = new Car();
      c.Make = "Honda";
      c.Model = "Jazz";
      c.PlateNo = DateTime.Now.Millisecond.ToString();

      c.AddFillUp(1000, 40.0);
      c.AddFillUp(1600, 50.0);
      c.AddFillUp(2200, 60.0);

      _carService.Add(c);
      _carService.SaveChanges();
    }
  }
}