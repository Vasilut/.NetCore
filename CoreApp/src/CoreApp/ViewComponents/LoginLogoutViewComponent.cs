using Microsoft.AspNetCore.Mvc;

namespace CoreApp.ViewComponents
{
    public class LoginLogoutViewComponent: ViewComponent
    {
        public LoginLogoutViewComponent()
        {

        }

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
