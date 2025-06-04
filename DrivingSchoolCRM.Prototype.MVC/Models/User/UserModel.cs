using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DrivingSchoolCRM.Prototype.MVC.Models.User.Enums;

namespace DrivingSchoolCRM.Prototype.MVC.Models.User
{
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string UserFirstName { get; set; }
        [Required]
        public string UserLastName { get; set; }
        [Required]
        public string UserGender { get; set; }
        [Required]
        public string UserIDNumber { get; set; }
        [Required]
        public string UserPassword { get; set; }
        [Required]
        public string UserAddress { get; set; }
        [Required]
        public string UserCity { get; set; }
        [Required]
        public string UserEmailAddress { get; set; }
        [Required]
        public string UserPhoneNumber { get; set; }
        [Required]
        public string UserEmergencyContact { get; set; }
        [Required]
        public UserRole UserRole { get; set; }
    }
}
