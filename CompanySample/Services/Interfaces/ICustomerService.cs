using CompanySample.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanySample.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IList<Customer>> GetCustomers();

        Task<Customer> GetCustomer(int id);

        Task PutCustomer(int id, Customer customer);

        Task PostCustomer(Customer customer);

        Task DeleteCustomer(Customer customer);

        Task<bool> CustomerExists(int id);
    }
}
