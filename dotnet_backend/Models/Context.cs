using Microsoft.EntityFrameworkCore;

namespace dog_breed_world.Models
{
   public class Context : DbContext
  {
    private readonly IConfiguration _config;
    public Context(DbContextOptions options, IConfiguration config) : base(options)
    {
      _config = config;
    }
    public DbSet<User>? Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseMySql(_config["connectionString"], ServerVersion.AutoDetect(_config["connectionString"]));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<User>(entity =>
      {
        entity.HasKey(e => e.Id);
      });
    }
  }
}
