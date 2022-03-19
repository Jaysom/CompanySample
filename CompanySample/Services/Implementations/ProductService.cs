using CompanySample.Data;
using CompanySample.Models;
using CompanySample.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanySample.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly CompanySampleContext _context;

        public ProductService(CompanySampleContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IList<Product>> GetProductsByCustomerId(int customerId)
        {
            return await _context.Customers.Where(a => a.Id == customerId).Select(b => b.CustomerProducts.ToList()).FirstOrDefaultAsync();
        }

        public async Task PutProduct(int id, Product product)
        {
            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
        }

        public async Task PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

        }

        public async Task<bool> ProductExists(int id)
        {
            return await _context.Products.AnyAsync(e => e.Id == id);
        }

    }
}
