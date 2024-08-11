using Microsoft.EntityFrameworkCore;
using IronDome.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Configuration;
namespace IronDome.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            Seed();
        }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
        public void Seed()
        {
            if (!Admin.Any())
            {
                AdminModel nnew = new()
                {
                    MissileAmount = 200,
                };
                Admin.Add(nnew);
                SaveChanges();
            }
        }


        public DbSet<ThreatModel> Threats { get; set; }
        public DbSet<AdminModel> Admin { get; set; }
    }

}


