using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ustaVideosB.Models;

namespace ustaVideosB.Data;

public class ApplicationDbContext : IdentityDbContext //<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
    public DbSet<Cinema> Cinema { get; set; }
    public DbSet<Actor> Actor { get; set; }
    public DbSet<Director> Director { get; set; }
    public DbSet<Movie> Movie { get; set; }
    public DbSet<Actor_Movies> Actor_Movies { get; set; }
}
