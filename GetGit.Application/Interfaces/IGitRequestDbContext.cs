using Microsoft.EntityFrameworkCore;

public interface IGitRequestDbContext
{
    DbSet<GitRequest> GitRequests { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
