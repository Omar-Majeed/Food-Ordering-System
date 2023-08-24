using Food_Ordering_Web.Models;
using Food_Ordering_Web.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Food_Ordering_Web.Controllers
{
    public class RegisterController : Controller
    {
        private FoodOrderingContext db = new FoodOrderingContext();

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser(string name, string email, string phone, string password, string passwordConfirm)
        {

            if (password != passwordConfirm)
            {
                return View("Register", "Passwords Mismatched!!");
            }

            Customer obj = new Customer { Name = name, Email = email, Phone = phone, Password = password };

            CustomerRepository custRepo = new CustomerRepository(db);

            bool result = custRepo.RegisterCustomer(obj);

            Console.WriteLine(result);
            if (!result)
            {
                return View("Register", "User with Email Already Exists");
            }

            return RedirectToAction("Login","Login");
        }
    }
}
