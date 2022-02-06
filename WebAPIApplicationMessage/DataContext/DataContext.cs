using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPIApplicationMessage.DataContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Models.Product>  Products {  get; set; }
        public DbSet<Models.Category>  Categories {  get; set; }

    }
}
