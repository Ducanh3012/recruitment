using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using recruitment.Models; // Chắc chắn rằng bạn đã thêm namespace này nếu các models của bạn đặt ở một namespace khác

namespace recruitment.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		// Thêm DbSet cho mỗi model/entity
		public DbSet<UserApplication> UserApplications { get; set; }
		public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }
		public DbSet<CV> CVs { get; set; }
		public DbSet<JobCategory> JobCategories { get; set; }
		public DbSet<JobListing> JobListings { get; set; }
		public DbSet<Profile> Profiles { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Jobs>()
                .HasMany(j => j.Jobslisting)
                .WithOne(jl => jl.Jobs)
                .HasForeignKey(jl => jl.JobsId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "a1b2c3d4-role-id-for-admin", // Explicit ID for the role
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            // Seed user
            var hasher = new PasswordHasher<IdentityUser>();
            var adminUser = new IdentityUser
            {
                UserName = "admin@example.com",
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = string.Empty,
                Id = Guid.NewGuid().ToString() 
            };

            adminUser.PasswordHash = hasher.HashPassword(adminUser, "P@ssw0rd");

            modelBuilder.Entity<IdentityUser>().HasData(adminUser);

            // Seed user role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "a1b2c3d4-role-id-for-admin", // This should match the Role Id provided above
                UserId = adminUser.Id // Make sure this matches the Id of the user you have created
            });
        }
		public DbSet<recruitment.Models.Jobs> Jobs { get; set; } = default!;
	}
}
