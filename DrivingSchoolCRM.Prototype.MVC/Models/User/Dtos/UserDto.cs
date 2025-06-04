using DrivingSchoolCRM.Prototype.MVC.Models.User.Enums;
using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolCRM.Prototype.MVC.Models.User.Dtos
{
    public class UserDto
    {
        [Key]
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserGender { get; set; }
        public string UserIDNumber { get; set; }
        public string UserPassword { get; set; }
        public string UserAddress { get; set; }
        public string UserCity { get; set; }
        public string UserEmailAddress { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserEmergencyContact { get; set; }
        public UserRole UserRole { get; set; }
    }
}
