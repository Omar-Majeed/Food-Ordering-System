namespace Food_Ordering_Web.Models.Repositories
{
    public class CustomerRepository
    {
        private FoodOrderingContext db;
        public CustomerRepository(FoodOrderingContext dbContext)
        {
            db = dbContext;
        }

        public Customer ValidateCustomer(string email, string password)
        {
            var customer = db.Customers.Where(cust => (cust.Email== email && cust.Password== password)).FirstOrDefault();
            Console.WriteLine(customer);
            return customer;
        }

        public bool RegisterCustomer(Customer cust)
        {
            var customer = db.Customers.Where(stu => stu.Email == cust.Email);
            
            Console.WriteLine(customer);
            if(customer.Any())
            {
                return false;
            }

            db.Customers.Add(cust);
            db.SaveChanges();
            return true;
        }

    }
}
