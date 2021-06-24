using DeveloperTest.Models;

namespace DeveloperTest.Business.Interfaces
{
    public interface ICustomerService
    {
        CustomerModel CreateCustomer(CustomerModel model);
        CustomerModel GetCustomer(int customerID);
        CustomerModel[] GetCustomers();
    }
}