using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proiect.Models;

namespace proiect.Data
{
    public class proiectContext : DbContext
    {
        public proiectContext (DbContextOptions<proiectContext> options)
            : base(options)
        {
        }

        public DbSet<proiect.Models.Curs> Curs { get; set; } = default!;

        public DbSet<proiect.Models.Artist>? Artist { get; set; }

        public DbSet<proiect.Models.TipBilet>? TipBilet { get; set; }

        public DbSet<proiect.Models.Client>? Client { get; set; }

        public DbSet<proiect.Models.Inscriere>? Inscriere { get; set; }


    }
}
