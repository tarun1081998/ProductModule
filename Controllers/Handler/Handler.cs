using ProductModule.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductModule.Controllers.Handler{

public class Handler: IHandler
{
    public ProductContext _context;
    public Handler(ProductContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProducts(){
        var products = await _context.Products.ToListAsync();
        return products;
    }

    public async Task PostProduct(Product product){
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task EditProduct(int id,Product product){
        var p1 = await _context.Products.Where(pd => pd.Id==id).ToListAsync();
        Product p;
        if(p1.Count()==0){
            throw new Exception("Product not found");
        }
        else
        {
            p=p1[0];
        }
        p.Name = product.Name;
        p.Description = product.Description;
        p.Price = product.Price;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProduct(int id){
        
        Product product;
        List<Product> p = await _context.Products.Where(p=>p.Id==id).ToListAsync();
        if(p.Count()==0){
            throw new Exception("Product not found");
        }
        else
        {
            product=p[0];
        }
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}

}