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
            new District { Id = 5, LocationName = "Bağcılar" },
            new District { Id = 6, LocationName = "Adalar" },
            new District { Id = 7, LocationName = "Arnavutköy" },
            new District { Id = 8, LocationName = "Ataşehir" },
            new District { Id = 9, LocationName = "Avcılar" },
            new District { Id = 10, LocationName = "Bahçelievler" },
            new District { Id = 11, LocationName = "Bakırköy" },
            new District { Id = 12, LocationName = "Başakşehir" },
            new District { Id = 13, LocationName = "Bayrampaşa" },
            new District { Id = 14, LocationName = "Beşiktaş" },
            new District { Id = 15, LocationName = "Beykoz" },
            new District { Id = 16, LocationName = "Beylikdüzü" },
            new District { Id = 17, LocationName = "Beyoğlu" },
            new District { Id = 18, LocationName = "Büyükçekmece" },
            new District { Id = 19, LocationName = "Çatalca" },
            new District { Id = 20, LocationName = "Çekmeköy" },
            new District { Id = 21, LocationName = "Esenler" },
            new District { Id = 22, LocationName = "Esenyurt" },
            new District { Id = 23, LocationName = "Eyüpsultan" },
            new District { Id = 24, LocationName = "Fatih" },
            new District { Id = 25, LocationName = "Gaziosmanpaşa" },
            new District { Id = 26, LocationName = "Güngören" },
            new District { Id = 27, LocationName = "Küçükçekmece" },
            new District { Id = 28, LocationName = "Kağıthane" },
            new District { Id = 29, LocationName = "Kartal" },
            new District { Id = 30, LocationName = "Pendik" },
            new District { Id = 31, LocationName = "Sancaktepe" },
            new District { Id = 32, LocationName = "Sarıyer" },
            new District { Id = 33, LocationName = "Silivri" },
            new District { Id = 34, LocationName = "Sultanbeyli" },
            new District { Id = 35, LocationName = "Sultangazi" },
            new District { Id = 36, LocationName = "Şile" },
            new District { Id = 37, LocationName = "Şişli" },
            new District { Id = 38, LocationName = "Tuzla" },
            new District { Id = 39, LocationName = "Zeytinburnu" }
            
            
            );

            modelBuilder.Entity<House>().HasData(new House { Id = 1, Title = "Güzel Ev", Square = 100, RoomNumber = 3, Price = 9000, LocationId = 1, StatusId = 1 },
            new House { Id = 2, Title = "Ucuz Ev", Square = 120, RoomNumber = 5, Price = 1150000, LocationId = 2, StatusId = 2 },
            new House { Id = 3, Title = "Ucuz Ev", Square = 120, RoomNumber = 5, Price = 1150000, LocationId = 3, StatusId = 1 },
            new House { Id = 4, Title = "Ucuz Ev", Square = 120, RoomNumber = 5, Price = 1150000, LocationId = 4, StatusId = 1 },
            new House { Id = 5, Title = "Ucuz Ev", Square = 120, RoomNumber = 5, Price = 1150000, LocationId = 5, StatusId = 2 },
            new House { Id = 6, Title = "Ucuz Ev", Square = 120, RoomNumber = 5, Price = 1150000, LocationId = 6, StatusId = 1 },
            new House { Id = 7, Title = "Ucuz Ev", Square = 120, RoomNumber = 5, Price = 1150000, LocationId = 7, StatusId = 1 },
            new House { Id = 8, Title = "Ucuz Ev", Square = 120, RoomNumber = 5, Price = 1150000, LocationId = 8, StatusId = 2 },
            new House { Id = 9, Title = "Ucuz Ev", Square = 120, RoomNumber = 5, Price = 1150000, LocationId = 9, StatusId = 2 }
        );
        }
    }
}
