using IronDome.Models;
using Microsoft.EntityFrameworkCore;

namespace IronDome.Service
{
    public class HomeService: IHomeService
    {
    }
}

/*


public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : DbContext(options)
{
    private readonly IConfiguration _configuration = configuration;

    DbSet<ThreatModel> Threats { get; set; }
    DbSet<Defenseodel> Defenses { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    }
 */