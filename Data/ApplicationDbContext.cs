using Microsoft.EntityFrameworkCore;
using GestionEvenements.Models;

namespace GestionEvenements.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<Organisateur> Organisateurs { get; set; }
    }
}