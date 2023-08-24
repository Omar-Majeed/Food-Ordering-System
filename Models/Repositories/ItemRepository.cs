namespace Food_Ordering_Web.Models.Repositories
{
    public class ItemRepository
    {
        private FoodOrderingContext dbContext;

        public ItemRepository(FoodOrderingContext db)
        {
            dbContext = db;
        }

        public List<Item> getFastFood()
        {
            var items = dbContext.Items.Where(item => (item.FoodType == "Fast Food"));
            if (!items.Any())
            {
                return new List<Item>(); // Return an empty list
            }

            return items.ToList();
        }

        public List<Item> getDesiFood()
        {
            var items = dbContext.Items.Where(item => (item.FoodType == "Desi Food"));
            if (!items.Any())
            {
                return new List<Item>(); // Return an empty list
            }

            return items.ToList();
        }

        public List<Item> getDessert()
        {
            var items = dbContext.Items.Where(item => (item.FoodType == "Dessert"));
            if (!items.Any())
            {
                return new List<Item>(); // Return an empty list
            }

            return items.ToList();
        }

        public void addItem(Item newItem)
        {
            dbContext.Items.Add(newItem);
            dbContext.SaveChanges();
        }
    }
}
