using Core.Reservations;
using Core.Spaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Reservations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasIndex(r => r.Id);

        builder.Property(t => t.StartDate)
            .HasConversion(d => DateTime.SpecifyKind(d, DateTimeKind.Utc), v => v);

        builder.Property(t => t.EndDate)
            .HasConversion(d => DateTime.SpecifyKind(d, DateTimeKind.Utc), v => v);

        builder.HasOne<Space>().WithMany().HasForeignKey(r => r.SpaceId);
    }
}