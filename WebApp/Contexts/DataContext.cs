using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace WebApp.Contexts;


public class DataContext :IdentityDbContext<UserEntity> // public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<UserAddressEntity> UserAddresses { get; set; }


    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<ProductTagEntity> ProductsTags { get; set; }


    public DbSet<ContactFormEntity> ContactForms { get; set; }
    public DbSet<UnitEntity> UnitEntity { get; set; } = default!;


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "4588f604-7d9e-47b1-ba46-c37c6489529f",
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            },

            new IdentityRole
            {
                Id = "8234adfe-9210-443c-8804-53af17ce2a38",
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            }
        );

        var passwordHasher = new PasswordHasher<UserEntity>();
        var userEntity = new UserEntity
        {
            Id = "7188fe27-04ef-4f0b-8f0d-dd466800e0fa",
            UserName = "admin@domain.com",
            NormalizedUserName = "ADMIN@DOMAIN.COM",
            Email = "admin@domain.com",
            NormalizedEmail = "ADMIN@DOMAIN.COM",
            ConcurrencyStamp = Guid.NewGuid().ToString()
        };
        userEntity.PasswordHash = passwordHasher.HashPassword(userEntity, "Admin123!");
        builder.Entity<UserEntity>().HasData(userEntity);

        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            UserId = userEntity.Id,
            RoleId = "4588f604-7d9e-47b1-ba46-c37c6489529f"
        });

        builder.Entity<TagEntity>().HasData(
            new TagEntity { Id = 1, TagName = "new" },
            new TagEntity { Id = 2, TagName = "featured" },
            new TagEntity { Id = 3, TagName = "popular" }
            );

        builder.Entity<ProductEntity>().HasData(
            new ProductEntity
            {
                Id = 1,
                Title = "Logitech",
                ImageUrl = "asdfasdf",
                Description = "Trådlös mus",
                Price = 100
            });

        builder.Entity<ProductTagEntity>().HasData(
            new ProductTagEntity
            {
                ProductId = 1,
                TagId = 1
            }
            );
    }
}
