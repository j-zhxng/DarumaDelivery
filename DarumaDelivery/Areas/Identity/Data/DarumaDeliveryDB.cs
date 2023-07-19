using DarumaDelivery.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DarumaDelivery.Models;

namespace DarumaDelivery.Areas.Identity.Data;

public class DarumaDeliveryDB : IdentityDbContext<DarumaDeliveryUser>
{
    public DarumaDeliveryDB(DbContextOptions<DarumaDeliveryDB> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<DarumaDelivery.Models.Customer>? Customer { get; set; }

    public DbSet<DarumaDelivery.Models.Register>? Register { get; set; }

    public DbSet<DarumaDelivery.Models.Product>? Product { get; set; }
}
