using ProductModule.Models;
namespace ProductModule.Controllers.Handler{
    public interface IHandler
    {
        Task<List<Product>> GetProducts();
        Task PostProduct(Product product);
        Task EditProduct(int id,Product product);
        Task DeleteProduct(int id);
    }
}
