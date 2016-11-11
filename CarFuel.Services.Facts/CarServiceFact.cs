using CarFuel.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarFuel.Services.Facts {
  public class CarServiceFact { 

    public class Add {

      [Fact]
      public void PlateNoMustBeUniqued() {
        var mock = new Mock<IUserService>();

        mock.Setup(m => m.IsLoggedIn()).Returns(true);
        mock.Setup(m => m.CurrentUserId()).Returns(Guid.NewGuid().ToString());


        var repo = new FakeRepository<Car>();
        var s = new CarService(repo, mock.Object);
        var c1 = new Car { PlateNo = "123" };
        var c2 = new Car { PlateNo = "123" };

        s.Add(c1);

        Assert.Throws<Exception>(() => {
          s.Add(c2);
        });

      }

      [Fact]
      public void UserCanAddNotMoreThanTwoCars() {
        var mock = new Mock<IUserService>();

        mock.Setup(m => m.IsLoggedIn()).Returns(true);
        mock.Setup(m => m.CurrentUserId()).Returns(Guid.NewGuid().ToString());

        var repo = new FakeRepository<Car>();
        var s = new CarService(repo, mock.Object);
        var c1 = new Car { PlateNo = "123" };
        var c2 = new Car { PlateNo = "124" };
        var c3 = new Car { PlateNo = "125" };

        s.Add(c1);
        s.Add(c2);

        Assert.Throws<Exception>(() => {
          s.Add(c3);
        });
      }
    }
  }
}
