using BuildCompany.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BuildCompany.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ServiceCategory> ServiceCategories { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string adminName = "admin";
            string roleAdminId = "824A3D06-1681-4CC0-96CC-864DF582C5E1";
            string userAdminId = "D86D4A7E-4934-4726-B0E9-B6C063B0FE81";

            builder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Name = adminName,
                Id = roleAdminId,
                NormalizedName = adminName.ToUpper()
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser()
            {
                Id = userAdminId,
                UserName = adminName,
                NormalizedUserName = adminName.ToUpper(),
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(new IdentityUser(), adminName),
                SecurityStamp = string.Empty,
                PhoneNumberConfirmed = true
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>()
            {
                UserId = userAdminId,
                RoleId = roleAdminId
            });
        }
    }
}
