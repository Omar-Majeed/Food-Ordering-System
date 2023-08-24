using Food_Ordering_Web.Models;
using Food_Ordering_Web.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Food_Ordering_Web.Controllers
{
    public class AdminController : Controller
    {

        private FoodOrderingContext db = new FoodOrderingContext();


        public IActionResult Index()
        {
            if (HttpContext.Request.Cookies.ContainsKey("admin"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login","Home");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("admin");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddDish()
        {
            if (HttpContext.Request.Cookies.ContainsKey("admin"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public IActionResult AddNewDish(string type, string dishName,string price,string path)
        {
            if (HttpContext.Request.Cookies.ContainsKey("admin"))
            {

                Item newItem = new Item { FoodType = type, Name = dishName, Price = price, ImagePath = path };

                ItemRepository repo = new ItemRepository(db);
                repo.addItem(newItem);

                return View("AddDish","Item Added Successfully!!!");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public IActionResult AllUsers()
        {
            return View();
        }

        public List<Customer> getAllUsers()
        {
            Console.WriteLine("IN there");
            return db.Customers.ToList();
        }

    }
}
