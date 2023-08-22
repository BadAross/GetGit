using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class GitRequestConfiguration : IEntityTypeConfiguration<GitRequest>
{
    public void Configure(EntityTypeBuilder<GitRequest> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique();
        builder.Property(x => x.RequestText).HasMaxLength(300);
    }
}
