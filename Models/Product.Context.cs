using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductModule.Models
{
    public class ProductContext: DbContext
    {

        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {

        }
        public virtual DbSet<Product> Products { get; set; }
    }
}