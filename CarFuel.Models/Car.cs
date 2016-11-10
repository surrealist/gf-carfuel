using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CarFuel.Models {
  public class Car {

    public Car() {
      Make = "Make";
      Model = "Model";
      FillUps = new HashSet<FillUp>();
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [StringLength(20)]
    public string Make { get; set; }

    [Required]
    [StringLength(30)]
    public string Model { get; set; }

    public virtual ICollection<FillUp> FillUps { get; set; }

    public double? AverageConsumptionRate {
      get {
        if (FillUps.Count <= 1) {
          return null;
        }

        int? totalDistance = FillUps.Sum(f => f.Distance);
        double? totalLiters = FillUps.Sum(f => f.Liters)
                             - FillUps.FirstOrDefault()?.Liters;

        return Math.Round((totalDistance / totalLiters) ?? 0.0,
                         2, MidpointRounding.AwayFromZero);
      }
    }


    public FillUp AddFillUp(int odometer, double liters) {
      var f = new FillUp() {
        Odometer = odometer,
        Liters = liters
      };

      if (FillUps.Any()) {
        FillUps.Last().NextFillUp = f;
      }

      FillUps.Add(f);
      return f;
    }
  }
}