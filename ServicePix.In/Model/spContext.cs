using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePix.In.Model
{
    public class spContext : DbContext
    {
        public DbSet<Acao> Acao { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<MotorAuxiliar> MotorAuxiliar { get; set; }
        public DbSet<Parametro> Parametro { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("InDb");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
