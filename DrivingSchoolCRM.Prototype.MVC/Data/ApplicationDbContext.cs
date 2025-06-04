using DrivingSchoolCRM.Prototype.MVC.Models.User;
using DrivingSchoolCRM.Prototype.MVC.Models.User.Enums;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchoolCRM.Prototype.MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {          
        }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserModel>().HasData(
                new UserModel
                {
                    UserId = 1,
                    UserFirstName = "Thabo",
                    UserLastName = "Mokoena",
                    UserGender = "Male",
                    UserIDNumber = "8901015800081",
                    UserPassword = "Password123", // In production, hash it
                    UserAddress = "123 Long Street",
                    UserCity = "Cape Town",
                    UserEmailAddress = "thabo.mokoena@example.com",
                    UserPhoneNumber = "0721234567",
                    UserEmergencyContact = "0749876543",
                    UserRole = UserRole.Student
                },
                new UserModel
                {
                    UserId = 2,
                    UserFirstName = "Lindiwe",
                    UserLastName = "Ngcobo",
                    UserGender = "Female",
                    UserIDNumber = "9402254800082",
                    UserPassword = "SecurePass456",
                    UserAddress = "45 Kloof Street",
                    UserCity = "Cape Town",
                    UserEmailAddress = "lindiwe.ngcobo@example.com",
                    UserPhoneNumber = "0787654321",
                    UserEmergencyContact = "0763456789",
                    UserRole = UserRole.Instructor
                }
            );
        }

    }
}
