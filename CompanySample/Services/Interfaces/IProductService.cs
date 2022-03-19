using CompanySample.Models;

namespace CompanySample.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<IList<Product>> GetProductsByCustomerId(int customerId);
        Task PutProduct(int id, Product product);
        Task PostProduct(Product product);
        Task DeleteProduct(Product product);
        Task<bool> ProductExists(int id);
    }
}
