using KihoonShopes.Entities;

namespace KihoonShopApp.Models
{
    public class CustomersViewModel
    {
        public List<Customer> Customers { get; set; }

        public string ActivePage { get; set; } = "A-E";
    }
}
