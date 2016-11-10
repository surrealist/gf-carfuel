using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarFuel.Models.Facts {
  public class CarFact {

    public class GeneralUsage {

      [Fact]
      public void NewCar() {
        Car c = new Car();

        Assert.Equal("Make", c.Make);
        Assert.Equal("Model", c.Model);
        Assert.NotNull(c.FillUps);
        Assert.Empty(c.FillUps);
      }
    }

    public class AddFillUpMethod {

      [Fact]
      public void AddFirstFillUp() {
        Car c = new Car();

        FillUp f1 = c.AddFillUp(odometer: 1000, liters: 40.0);

        Assert.Equal(1, c.FillUps.Count());
        Assert.Equal(1000, f1.Odometer);
        Assert.Equal(40.0, f1.Liters);
      }

      [Fact]
      public void AddTwoFillUps() {
        Car c = new Car();

        FillUp f1 = c.AddFillUp(odometer: 1000, liters: 40.0);
        FillUp f2 = c.AddFillUp(odometer: 1600, liters: 50.0);

        Assert.Same(f2, f1.NextFillUp);
        Assert.Equal(2, c.FillUps.Count());
      }
    }

    public class AverageConsumptionRateProperty {

      [Fact]
      public void NoFillUps_ReturnsNull() {
        var c = new Car();
        Assert.Null(c.AverageConsumptionRate);
      }

      [Fact]
      public void SingleFillUp() {
        var c = new Car();
        c.AddFillUp(1000, 40.0);
        Assert.Null(c.AverageConsumptionRate);
      }

      [Fact]
      public void TwoFillUps() {
        var c = new Car();
        c.AddFillUp(1000, 40.0);
        c.AddFillUp(1600, 50.0);
        Assert.Equal(12.0, c.AverageConsumptionRate);
      }


      [Fact]
      public void ThreeFillUps() {
        var c = new Car();
        c.AddFillUp(1000, 40.0);
        c.AddFillUp(1600, 50.0);
        c.AddFillUp(2200, 60.0);
        Assert.Equal(10.91, c.AverageConsumptionRate);
      }
    }


  }
}
