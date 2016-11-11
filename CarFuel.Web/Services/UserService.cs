using CarFuel.Services;
using System.Web;
using Microsoft.AspNet.Identity;

namespace CarFuel.Web.Services {
  public class UserService : IUserService {

    public string CurrentUserId() {
      return HttpContext.Current.User.Identity.GetUserId();
    }

    public bool IsLoggedIn() {
      return HttpContext.Current.User.Identity.IsAuthenticated;
    }
  }
}