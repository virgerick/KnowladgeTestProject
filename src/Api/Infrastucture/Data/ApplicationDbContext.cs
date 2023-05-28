


using Api.Core.Invoices.Configurations;
using Api.Core.Orders.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;
public sealed class ApplicationDbContext:DbContext
{
    public DbSet<Order> Orders { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options
        ):base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
    }
}