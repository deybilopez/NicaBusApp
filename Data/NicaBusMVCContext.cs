using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NicaBusMVC.Models;

namespace NicaBusMVC.Data
{
    public class NicaBusMVCContext : DbContext
    {
        public NicaBusMVCContext (DbContextOptions<NicaBusMVCContext> options)
            : base(options)
        {
        }

        public DbSet<NicaBusMVC.Models.DetallesViaje> DetallesViaje { get; set; } = default!;

        public DbSet<NicaBusMVC.Models.Ruta> Ruta { get; set; }

        public DbSet<NicaBusMVC.Models.User> User { get; set; }
    }
}
