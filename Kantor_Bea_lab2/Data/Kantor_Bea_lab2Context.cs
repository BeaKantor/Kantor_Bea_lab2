using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kantor_Bea_lab2.Models;

namespace Kantor_Bea_lab2.Data
{
    public class Kantor_Bea_lab2Context : DbContext
    {
        public Kantor_Bea_lab2Context (DbContextOptions<Kantor_Bea_lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Kantor_Bea_lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Kantor_Bea_lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Kantor_Bea_lab2.Models.Author> Author { get; set; } = default!;
    }
}
