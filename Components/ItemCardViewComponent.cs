using Food_Ordering_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Food_Ordering_Web.Views.Shared.Components
{
    public class ItemCardViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(List<Item> data)
        {
            Console.WriteLine("in the component");
            Console.Write(data);
            return View(data);
        }
    }
}
