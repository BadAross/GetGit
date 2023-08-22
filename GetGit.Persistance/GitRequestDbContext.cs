using Microsoft.EntityFrameworkCore;

public class GitRequestDbContext : DbContext, IGitRequestDbContext
{
    public DbSet<GitRequest> GitRequests { get; set; }

    public GitRequestDbContext(DbContextOptions<GitRequestDbContext> options) :
        base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new GitRequestConfiguration());
        base.OnModelCreating(builder);
    }
}
