using System.Collections.Generic;

namespace CarFuel.Models {
  public class FillUp {
    public double? ConsumptionRate {
      get {
        if (NextFillUp == null) return null;

        return (NextFillUp.Odometer - Odometer)
          / NextFillUp.Liters;
      }
    }

    public bool IsFull { get; set; } = true;
    public double Liters { get; set; }
    public FillUp NextFillUp { get; set; }
    public int Odometer { get; set; }

    internal int? Distance {
      get {
        return NextFillUp?.Odometer - Odometer;
        //if (NextFillUp == null) return null;
        //return NextFillUp.Odometer - Odometer;
      }
    }
  }
}