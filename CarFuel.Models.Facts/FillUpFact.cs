using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarFuel.Models.Facts {
  public class FillUpFact {

    public class GeneralUsage {

      [Fact]
      public void NewFillUp() {
        FillUp f;

        f = new FillUp();

        Assert.Equal(0, f.Odometer);
        Assert.Equal(0.0, f.Liters);
        Assert.True(f.IsFull);
      }

    }

    public class ConsumptionRateProp {

      [Fact]
      public void FirstFillUp_ReturnsNull() {
        var f = new FillUp();
        f.Odometer = 1000;
        f.Liters = 40;

        double? result = f.ConsumptionRate;

        Assert.Null(result);
      }

      [Theory]
      [InlineData(1000, 40, 12.0, 1600, 50)]
      [InlineData(1600, 50, 10.0, 2200, 60)]
      public void TwoFullFillUps(int odo1, double liters1, double kml1, 
                                 int odo2, double liters2) {
        var f1 = new FillUp();
        f1.Odometer = odo1; f1.Liters = liters1;
        var f2 = new FillUp();
        f2.Odometer = odo2; f2.Liters = liters2;

        f1.NextFillUp = f2;

        double? result1 = f1.ConsumptionRate;
        double? result2 = f2.ConsumptionRate;

        Assert.Equal(kml1, result1);
        Assert.Null(result2);
      }

      [Fact]
      public void TwoFullFillUps_I() {
        var f1 = new FillUp();
        f1.Odometer = 1000; f1.Liters = 40.0;
        var f2 = new FillUp();
        f2.Odometer = 1600; f2.Liters = 50.0;

        f1.NextFillUp = f2;

        double? result1 = f1.ConsumptionRate;
        double? result2 = f2.ConsumptionRate;

        Assert.Equal(12.0, result1);
        Assert.Null(result2);
      }

      [Fact]
      public void TwoFullFillUps_II() {
        var f2 = new FillUp();
        f2.Odometer = 1600; f2.Liters = 50.0;
        var f3 = new FillUp();
        f3.Odometer = 2200; f3.Liters = 60.0;

        f2.NextFillUp = f3;

        double? result2 = f2.ConsumptionRate;
        double? result3 = f3.ConsumptionRate;

        Assert.Equal(10.0, result2);
        Assert.Null(result3);
      }
    }
  }
}
