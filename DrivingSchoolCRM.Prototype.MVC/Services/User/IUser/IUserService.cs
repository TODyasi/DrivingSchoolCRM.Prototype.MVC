using DrivingSchoolCRM.Prototype.MVC.Models.User.Dtos;

namespace DrivingSchoolCRM.Prototype.MVC.Services.User.IUser
{
    public interface IUserService
    {
        Task<ResponseDto?> GetUserByIdAsync(int userId);
        Task<ResponseDto?> GetAllUsersAsync();
        Task<ResponseDto?> CreateUserAsync(UserDto userDto);
        Task<ResponseDto?> DeleteUserAsync(int userId);
        Task<ResponseDto?> UpdateUserAsync(UserDto userDto);
        Task<ResponseDto?> RegisterUserAsync(RegisterUserDto registerUserDto);
    }
}
