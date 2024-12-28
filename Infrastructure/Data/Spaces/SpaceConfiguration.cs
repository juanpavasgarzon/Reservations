using Core.Spaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Spaces;

public class SpaceConfiguration: IEntityTypeConfiguration<Space>
{
    public void Configure(EntityTypeBuilder<Space> builder)
    {
        builder.HasIndex(s => s.Id);

        builder.HasIndex(s => s.Name).IsUnique();
    }
}