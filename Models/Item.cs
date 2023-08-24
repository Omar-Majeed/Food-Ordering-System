using System;
using System.Collections.Generic;

namespace Food_Ordering_Web.Models;

public partial class Item
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Price { get; set; }

    public string? ImagePath { get; set; }

    public string? FoodType { get; set; }


}
