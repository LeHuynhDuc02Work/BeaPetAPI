using Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderAddress> OrderAddresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ShopCart> ShopCarts { get; set; }
        public DbSet<Slider> Sliders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //OrderDetail, Order, Product
            modelBuilder.Entity<OrderDetail>()
                .HasKey(pfk => new { pfk.ProductId, pfk.OrderId});

            modelBuilder.Entity<Product>()
                .HasMany(b => b.OrderDetails)
                .WithOne(p => p.Product)
                .HasForeignKey(fk => fk.ProductId);

            modelBuilder.Entity<Order>()
                .HasMany(b => b.OrderDetails)
                .WithOne(p => p.Order)
                .HasForeignKey(fk => fk.OrderId);

            //Product, Brand
            modelBuilder.Entity<Brand>()
                .HasMany(b => b.Products)
                .WithOne(p => p.Brand)
                .HasForeignKey(fk => fk.BrandId);

            //Product, ProductCategory
            modelBuilder.Entity<ProductCategory>()
                .HasMany(b => b.Products)
                .WithOne(p => p.ProductCategory)
                .HasForeignKey(fk => fk.ProductCategoryId);

            //ShopCart, Product
            modelBuilder.Entity<Product>()
                 .HasMany(b => b.ShopCarts)
                 .WithOne(p => p.Product)
                 .HasForeignKey(fk => fk.ProductId);

            //ShopCart, User
            //modelBuilder.Entity<User>()
            //    .HasNoKey();

            modelBuilder.Entity<User>()
                 .HasMany(b => b.ShopCarts)
                 .WithOne(p => p.User)
                 .HasForeignKey(fk => fk.UserId);

            //Oder, OrderAddress
            modelBuilder.Entity<OrderAddress>()
                 .HasMany(b => b.Orders)
                 .WithOne(p => p.Address)
                 .HasForeignKey(fk => fk.AddressId);

            new DbInitializer(modelBuilder).Seed();
            base.OnModelCreating(modelBuilder);
        }

        public class DbInitializer
        {
            private readonly ModelBuilder _modelBuilder;

            public DbInitializer(ModelBuilder modelBuilder)
            {
                _modelBuilder = modelBuilder;
            }

            public void Seed()
            {
                //Brand
                _modelBuilder.Entity<Brand>().HasData(
               new Brand { Id = 1,  Name = "Brand 1", Description = "Description brand 1", Image = ".//./brand1" },
               new Brand { Id = 2,  Name = "Brand 2", Description = "Description brand 1", Image = ".//./brand1" },
               new Brand { Id = 3,  Name = "Brand 3", Description = "Description brand 1", Image = ".//./brand1" },
               new Brand { Id = 4,  Name = "Brand 4", Description = "Description brand 1", Image = ".//./brand1" },
               new Brand { Id = 5,  Name = "Brand 5", Description = "Description brand 1", Image = ".//./brand1" }
               );
                //Menu
                _modelBuilder.Entity<Menu>().HasData(
               new Menu { Id = 1, Name = "Menu 1", Description = "Description Menu 1", Position = 1 },
               new Menu { Id = 2, Name = "Menu 2", Description = "Description Menu 2", Position = 2 },
               new Menu { Id = 3, Name = "Menu 3", Description = "Description Menu 3", Position = 3 },
               new Menu { Id = 4, Name = "Menu 4", Description = "Description Menu 4", Position = 4 },
               new Menu { Id = 5, Name = "Menu 5", Description = "Description Menu 5", Position = 5 },
               new Menu { Id = 6, Name = "Menu 6", Description = "Description Menu 6", Position = 6 }
               );
                //New
                _modelBuilder.Entity<New>().HasData(
               new New { Id = 1, Title = "Title 1", Description = "Description Title 1", Detail = "Detail New 1", Image = ".//./brand1" },
               new New { Id = 2, Title = "Title 2", Description = "Description Title 2", Detail = "Detail New 2", Image = ".//./brand1" },
               new New { Id = 3, Title = "Title 3", Description = "Description Title 3", Detail = "Detail New 3", Image = ".//./brand1" },
               new New { Id = 4, Title = "Title 4", Description = "Description Title 4", Detail = "Detail New 4", Image = ".//./brand1" },
               new New { Id = 5, Title = "Title 5", Description = "Description Title 5", Detail = "Detail New 5", Image = ".//./brand1" },
               new New { Id = 6, Title = "Title 6", Description = "Description Title 6", Detail = "Detail New 6x", Image = ".//./brand1" }
               );
                //OrderAddress
                _modelBuilder.Entity<OrderAddress>().HasData(
               new OrderAddress { Id = 1, NameCustomer = "Duc Le 1", Phone = "02882828", Address = "Ha Nam" },
               new OrderAddress { Id = 2, NameCustomer = "Duc Le 2", Phone = "02882828", Address = "Ha Nam" },
               new OrderAddress { Id = 3, NameCustomer = "Duc Le 3", Phone = "02882828", Address = "Ha Nam" },
               new OrderAddress { Id = 4, NameCustomer = "Duc Le 4", Phone = "02882828", Address = "Ha Nam" },
               new OrderAddress { Id = 5, NameCustomer = "Duc Le 5", Phone = "02882828", Address = "Ha Nam" }
               );

                //Order
                _modelBuilder.Entity<Order>().HasData(
               new Order { Id = 1, AddressId = 1, Code = 1, TotalAmount = 100.02, Quantity = 30 },
               new Order { Id = 2, AddressId = 2, Code = 2, TotalAmount = 200.02, Quantity = 30 },
               new Order { Id = 3, AddressId = 4, Code = 3, TotalAmount = 300.02, Quantity = 40 },
               new Order { Id = 4, AddressId = 5, Code = 4, TotalAmount = 400.02, Quantity = 20 },
               new Order { Id = 5, AddressId = 3, Code = 5, TotalAmount = 500.02, Quantity = 10 }
               );

                //Product
                _modelBuilder.Entity<Product>().HasData(
               new Product { Id = 1, BrandId = 1, ProductCategoryId = 1, Name = "Cho 1", 
                   Description = "An nhieu lam", Detail = "1m1", Image = "././.cho1",
                   Price = 100, SalePrice = 80, Quantity = 10
               },
               new Product { Id = 2, BrandId = 2, ProductCategoryId = 1, Name = "Cho 1", 
                   Description = "An nhieu lam", Detail = "1m1", Image = "././.cho1",
                   Price = 100, SalePrice = 80, Quantity = 10
               },
               new Product { Id = 3, BrandId = 3, ProductCategoryId = 1, Name = "Cho 1", 
                   Description = "An nhieu lam", Detail = "1m1", Image = "././.cho1",
                   Price = 100, SalePrice = 80, Quantity = 10
               },
               new Product { Id =4, BrandId = 4, ProductCategoryId = 1, Name = "Cho 1", 
                   Description = "An nhieu lam", Detail = "1m1", Image = "././.cho1",
                   Price = 100, SalePrice = 80, Quantity = 10
               },
               new Product { Id = 5, BrandId = 5, ProductCategoryId = 1, Name = "Cho 1", 
                   Description = "An nhieu lam", Detail = "1m1", Image = "././.cho1",
                   Price = 100, SalePrice = 80, Quantity = 10
               }
               );

                //OrderDetail
                _modelBuilder.Entity<OrderDetail>().HasData(
               new OrderDetail { Id = 1, OrderId = 1, ProductId = 1, Price = 100, Quantity = 10 },
               new OrderDetail { Id = 2, OrderId = 2, ProductId = 2, Price = 100, Quantity = 10 },
               new OrderDetail { Id = 3, OrderId = 1, ProductId = 3, Price = 100, Quantity = 10 },
               new OrderDetail { Id = 4, OrderId = 2, ProductId = 4, Price = 100, Quantity = 10 },
               new OrderDetail { Id = 5, OrderId = 1, ProductId = 5, Price = 100, Quantity = 10 }
               );

                //ProductCategory
                _modelBuilder.Entity<ProductCategory>().HasData(
               new ProductCategory { Id = 1, Name = "Name cate 1", Description = "Mo ta cate 1", Icon = "../../iicon1" },
               new ProductCategory { Id = 2, Name = "Name cate 2", Description = "Mo ta cate 2", Icon = "../../iicon1" },
               new ProductCategory { Id = 3, Name = "Name cate 3", Description = "Mo ta cate 3", Icon = "../../iicon1" },
               new ProductCategory { Id = 4, Name = "Name cate 4", Description = "Mo ta cate 4", Icon = "../../iicon1" },
               new ProductCategory { Id = 5, Name = "Name cate 5", Description = "Mo ta cate 5", Icon = "../../iicon1" },
               new ProductCategory { Id = 6, Name = "Name cate 6", Description = "Mo ta cate 6", Icon = "../../iicon1" }
               );

                //Slider
                _modelBuilder.Entity<Slider>().HasData(
               new Slider { Id = 1, Title = " Title slider", Description = "Descrip slider", Image = "../..//", Link = "./././" },
               new Slider { Id = 2, Title = " Title slider", Description = "Descrip slider", Image = "../..//", Link = "./././" },
               new Slider { Id = 3, Title = " Title slider", Description = "Descrip slider", Image = "../..//", Link = "./././" },
               new Slider { Id = 4, Title = " Title slider", Description = "Descrip slider", Image = "../..//", Link = "./././" }
               );
                //ShopCart
                //User
            }
        }
    }
}