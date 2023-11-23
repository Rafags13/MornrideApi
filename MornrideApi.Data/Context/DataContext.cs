using Microsoft.EntityFrameworkCore;
using MornrideApi.Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BikeCategory> BikesCategories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<BikeImage> BikeImages { get; set; }
        public DbSet<BannerImage> BannerImages { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
