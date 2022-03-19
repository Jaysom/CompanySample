using CompanySample.Data;
using CompanySample.Models;
using CompanySample.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanySample.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly CompanySampleContext _context;

        public CustomerService(CompanySampleContext context)
        {
            _context = context;
        }

        public async Task<IList<Customer>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task PutCustomer(int id, Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
        }

        public async Task PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomer(Customer customer)
        {
              
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CustomerExists(int id)
        {
            return await _context.Customers.AnyAsync(e => e.Id == id);
        }

    }
}
