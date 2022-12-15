using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Whatch.Models;

namespace Whatch.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class WhatchDbContext :
    AbpDbContext<WhatchDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Film> Films { get; set; }
    public DbSet<FilmReview> FilmReviews { get; set; }
    public DbSet<FilmCast> FilmCasts { get; set; }
    public DbSet<Watchlist> WatchLists { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public WhatchDbContext(DbContextOptions<WhatchDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();


        builder.Entity<Film>(b =>
        {
            b.ToTable("Films", WhatchConsts.DbSchema);
            b.ConfigureByConvention();

            b.Property(x => x.Title).HasMaxLength(255);
            b.Property(x => x.Description).HasMaxLength(1024);
            b.Property(x => x.Country).HasMaxLength(255);
        });
        
        builder.Entity<Actor>(b =>
        {
            b.ToTable("Actors", WhatchConsts.DbSchema);
            b.ConfigureByConvention();

            b.Property(x => x.Name).HasMaxLength(255);
            b.Property(x => x.Lastname).HasMaxLength(255);
        });
        
        builder.Entity<FilmCast>(b =>
        {
            b.ToTable("FilmCasts", WhatchConsts.DbSchema);
            b.ConfigureByConvention();

            b.Property(x => x.RoleName).HasMaxLength(255);
            
            b.HasOne(x => x.Actor)
                .WithMany(x => x.Casts)
                .HasForeignKey(x => x.ActorId);
            
            b.HasOne(x => x.Film)
                .WithMany(x => x.Casts)
                .HasForeignKey(x => x.FilmId);
        });
        
        builder.Entity<FilmReview>(b =>
        {
            b.ToTable("FilmReviews", WhatchConsts.DbSchema);
            b.ConfigureByConvention();

            b.Property(x => x.Review).HasMaxLength(2048);
            
            b.HasOne(x => x.Film)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.FilmId);
            
            b.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);
        });
        
        builder.Entity<Watchlist>(b =>
        {
            b.ToTable("Whatchlists", WhatchConsts.DbSchema);
            b.ConfigureByConvention();
            
            b.HasOne(x => x.Film)
                .WithMany()
                .HasForeignKey(x => x.FilmId);
            
            b.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);
        });
    }
}
