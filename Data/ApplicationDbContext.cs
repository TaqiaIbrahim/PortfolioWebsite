using Microsoft.EntityFrameworkCore;
using PortfolioWebsite.Models;

namespace PortfolioWebsite.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<AboutMe> AboutMe { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ClientOpinion> ClientOpinion { get; set; }
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<Expericence> Expericence { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Slider> Slider { get; set; }


    }

}
