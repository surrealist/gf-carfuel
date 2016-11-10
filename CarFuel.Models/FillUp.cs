using System.Collections.Generic;

namespace CarFuel.Models {
  public class FillUp {

    public int Id { get; set; }

    public bool IsFull { get; set; } = true;
    public double Liters { get; set; }
    public virtual FillUp NextFillUp { get; set; }
    public int Odometer { get; set; }

    public double? ConsumptionRate {
      get {
        if (NextFillUp == null) return null;

        return (NextFillUp.Odometer - Odometer)
          / NextFillUp.Liters;
      }
    }

    internal int? Distance {
      get {
        return NextFillUp?.Odometer - Odometer;
        //if (NextFillUp == null) return null;
        //return NextFillUp.Odometer - Odometer;
      }
    }
  }
}