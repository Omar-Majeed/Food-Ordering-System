using Microsoft.AspNetCore.Mvc;

namespace Food_Ordering_Web.Controllers
{
    public class LogoutController : Controller
    {
        public ActionResult Logout()
        {
            //HttpContext.Session.Remove("name");
            HttpContext.Response.Cookies.Delete("name");
            //HttpContext.Session.Remove("email");
            HttpContext.Response.Cookies.Delete("email");
            return RedirectToAction("Index", "Home");
        }
    }
}
