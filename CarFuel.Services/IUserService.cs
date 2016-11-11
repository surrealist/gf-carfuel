using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.Services {
  public interface IUserService {

    bool IsLoggedIn();
    string CurrentUserId();

  }
}
