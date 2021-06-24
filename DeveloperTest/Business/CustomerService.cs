using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Models;
using System.Linq;

namespace DeveloperTest.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext context;

        public CustomerService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public CustomerModel[] GetCustomers()
        {
            return context.Customers.Select(x => x.ToCustomerModel()).ToArray();
        }

        public CustomerModel GetCustomer(int customerID)
        {
            return context.Customers.Where(x => x.CustomerId == customerID).SingleOrDefault()?.ToCustomerModel();
        }
        public CustomerModel CreateCustomer(CustomerModel model)
        {
            var addedJob = context.Customers.Add(new Database.Models.Customer
            {
                Type = model.Type,
                Name = model.Name
            });
            context.SaveChanges();
            model.CustomerId = addedJob.Entity.CustomerId;
            return model;
        }

    }
}
