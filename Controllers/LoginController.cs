using Food_Ordering_Web.Models;
using Food_Ordering_Web.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Food_Ordering_Web.Controllers
{
    public class LoginController : Controller
    {
        private FoodOrderingContext db = new FoodOrderingContext();

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(string email, string password)
        {
            if (email == "admin" && password == "admin")
            {
                CookieOptions options = new CookieOptions();
                options.Expires = System.DateTime.Now.AddDays(3);
                //HttpContext.Session.SetString("admin", "admin");
                HttpContext.Response.Cookies.Append("admin", "admin", options);

                return RedirectToAction("Index", "Admin");
            }


            CustomerRepository custRepo = new CustomerRepository(db);
            Customer cust = custRepo.ValidateCustomer(email, password);
            if (cust != null)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = System.DateTime.Now.AddDays(3);
                //HttpContext.Session.SetString("name", cust.Name);
                HttpContext.Response.Cookies.Append("name", cust.Name, options);
                //HttpContext.Session.SetString("email", cust.Email);
                HttpContext.Response.Cookies.Append("email", cust.Email, options);

                return RedirectToAction("Index", "Home");
            }

            return View("Login", "Invalid Credentials!!!");
        }

    }

}
