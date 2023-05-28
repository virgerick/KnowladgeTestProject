
using Api.Core.Orders.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Core.Invoices.Configurations;
public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(e => e.OrderId);
        builder.Property(e => e.OrderId)
            .ValueGeneratedNever();
        builder.Property(x => x.ShipCountry)
            .HasMaxLength(528);
        builder.Property(x => x.CustomerId)
            .HasMaxLength(250);
        builder.Property(x => x.Freight)
            .HasColumnType("decimal(18,2)")
            .HasPrecision(18, 2);

        
    }
}