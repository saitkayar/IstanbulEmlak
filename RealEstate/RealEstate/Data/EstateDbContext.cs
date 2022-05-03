using Microsoft.EntityFrameworkCore;
using RealEstate.Models;

namespace RealEstate.Data
{
    public class EstateDbContext:DbContext
    {
        public EstateDbContext(DbContextOptions<EstateDbContext> options)
        : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<House> Houses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
             new User { UserID = 1, Email = "admin@test.com", UserName = "Admin", Password = "test123", RoleID = 3 },
             new User { UserID = 2, Email = "aktif@test.com", UserName = "aktif", Password = "test123", RoleID = 2 },
             new User { UserID = 3, Email = "pasif@test.com", UserName = "pasif", Password = "test123", RoleID = 1 }

             );
            modelBuilder.Entity<Role>().HasData(new Role { RoleID = 1, RoleName = "PasifKullanıcı" },
            new Role { RoleID = 2, RoleName = "AktifKullanıcı" },
            new Role { RoleID = 3, RoleName = "Admin" },
            new Role { RoleID = 4, RoleName = "Supervisor" });

            modelBuilder.Entity<Status>().HasData(new Status { Id = 1, Statu = "Kiralık" },
            new Status { Id = 2, Statu = "Satılık" });

            modelBuilder.Entity<District>().HasData(new District { Id = 1, LocationName = "Üsküdar" },
            new District { Id = 2, LocationName = "Ümraniye" },
            new District { Id = 3, LocationName = "Kadıköy" },
            new District { Id = 4, LocationName = "Maltepe" },
            new District { Id = 5, LocationName = "Bağcılar" });

            modelBuilder.Entity<House>().HasData(new House { Id = 1, Title = "Güzel Ev", Square = 100, RoomNumber = 3, Price = 9000, LocationId = 1, StatusId = 1 },
            new House { Id = 2, Title = "Ucuz Ev", Square = 120, RoomNumber = 5, Price = 1150000, LocationId = 2, StatusId = 2 }
        );
        }
    }
}
