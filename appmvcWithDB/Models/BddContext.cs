using Microsoft.EntityFrameworkCore;

namespace appmvcWithDB.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Sejour> Sejours { get; set; }
        public DbSet<Sondage> Sondages { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=choixsejour27");
        }
    }
}
