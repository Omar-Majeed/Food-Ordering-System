using Food_Ordering_Web.Models;
using Food_Ordering_Web.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Food_Ordering_Web.Controllers
{
    public class HomeController : Controller
    {
        private FoodOrderingContext db = new FoodOrderingContext();
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Register()
        {
            return View();
        }

        public ViewResult Login()
        {
            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        public ViewResult Menu()
        {
            ItemRepository items = new ItemRepository(db);
            List<Item> fastFood = items.getFastFood();

            return View(fastFood);
        }


        public ActionResult DesiFood()
        {
            ItemRepository items = new ItemRepository(db);
            List<Item> desiFood = items.getDesiFood();

            return View("Menu",desiFood);
        }

        public ActionResult Desserts()
        {
            ItemRepository items = new ItemRepository(db);
            List<Item> desserts = items.getDessert();

            return View("Menu", desserts);
        }

        public ViewResult Faq()
        {
            return View();
        }

        public ViewResult Services()
        {
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("name");
            HttpContext.Response.Cookies.Delete("email");
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public ActionResult LoginUser(string email, string password)
        {
            if(email == "admin" && password== "admin")
            {
                CookieOptions options = new CookieOptions();
                options.Expires = System.DateTime.Now.AddDays(3);
                //HttpContext.Session.SetString("admin", "admin");
                HttpContext.Response.Cookies.Append("admin", "admin", options);

                return RedirectToAction("Index", "Admin");
            }


            CustomerRepository custRepo = new CustomerRepository(db);
            Customer cust =  custRepo.ValidateCustomer(email, password);
            if(cust != null)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = System.DateTime.Now.AddDays(3);
                //HttpContext.Session.SetString("name", cust.Name);
                HttpContext.Response.Cookies.Append("name", cust.Name,options);
                //HttpContext.Session.SetString("email", cust.Email);
                HttpContext.Response.Cookies.Append("email", cust.Email,options);

                return RedirectToAction("Index","Home");
            }

            return View("Login", "Invalid Credentials!!!");
        }


        [HttpPost]
        public ViewResult RegisterUser(string name, string email, string phone, string password, string passwordConfirm)
        {

            if(password != passwordConfirm)
            {
                return View("Register", "Passwords Mismatched!!");
            }

            Customer obj = new Customer { Name=name,Email=email,Phone=phone,Password=password};

            CustomerRepository custRepo = new CustomerRepository(db);

            bool result = custRepo.RegisterCustomer(obj);

            Console.WriteLine(result);
            if (!result)
            {
                return View("Register", "User with Email Already Exists");
            }

            return View("Login");
        }
    }
}
