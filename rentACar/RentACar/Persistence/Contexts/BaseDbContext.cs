﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext: DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Model> Models{ get; set; }
        public DbSet<Transmission> Transmissions{ get; set; }
        public DbSet<Fuel> Fuel{ get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions,IConfiguration configuration):base(dbContextOptions)
        {
            Configuration = configuration;
            Database.EnsureCreated(); //Db olusturur, mevcut bir veritabanını değiştirmez veya güncellemez. 

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //Mevcut Assembly icerisindeki Configurasyonları bul ve uygula
            //IEntityTypeConfiguration  inherit alanlarını bulup ekliyor
        }

    }
}
