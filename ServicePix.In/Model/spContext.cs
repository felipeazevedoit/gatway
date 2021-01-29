using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public spContext(DbContextOptions<spContext> options) :
            base(options)
        {
        }

        public spContext()
        {
        }
    }
}
