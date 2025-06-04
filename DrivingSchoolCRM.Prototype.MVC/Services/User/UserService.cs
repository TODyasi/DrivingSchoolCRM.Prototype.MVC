using System;
using AutoMapper;
using DrivingSchoolCRM.Prototype.MVC.Data;
using DrivingSchoolCRM.Prototype.MVC.Mapping;
using DrivingSchoolCRM.Prototype.MVC.Models.User;
using DrivingSchoolCRM.Prototype.MVC.Models.User.Dtos;
using DrivingSchoolCRM.Prototype.MVC.Services.User.IUser;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchoolCRM.Prototype.MVC.Services.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ResponseDto?> CreateUserAsync(UserDto userDto)
        {
            var response = new ResponseDto();

            try
            {
                var userModel = _mapper.Map<UserModel>(userDto);

                _dbContext.Users.Add(userModel);
                await _dbContext.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "User created successfully.";
                response.Result = _mapper.Map<UserDto>(userModel);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error creating user: {ex.Message}";
            }

            return response;
        }

        public async Task<ResponseDto?> DeleteUserAsync(int userId)
        {
            var response = new ResponseDto();

            try
            {
                var user = await _dbContext.Users.FindAsync(userId);
                if (user == null)
                {
                    response.IsSuccess = false;
                    response.Message = "User not found.";
                    return response;
                }

                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "User deleted successfully.";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error deleting user: {ex.Message}";
            }

            return response;
        }

        public async Task<ResponseDto?> GetAllUsersAsync()
        {
            var response = new ResponseDto();

            try
            {
                var users = await _dbContext.Users.ToListAsync();
                var userDtos = _mapper.Map<List<UserDto>>(users);

                response.IsSuccess = true;
                response.Result = userDtos;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error retrieving users: {ex.Message}";
            }

            return response;
        }

        public async Task<ResponseDto?> GetUserByIdAsync(int userId)
        {
            var response = new ResponseDto();

            try
            {
                var user = await _dbContext.Users.FindAsync(userId);
                if (user == null)
                {
                    response.IsSuccess = false;
                    response.Message = "User not found.";
                    return response;
                }

                response.IsSuccess = true;
                response.Result = _mapper.Map<UserDto>(user);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error retrieving user: {ex.Message}";
            }

            return response;
        }

        public async Task<ResponseDto?> RegisterUserAsync(RegisterUserDto registerUserDto)
        {
            var response = new ResponseDto();

            try
            {
                var user = new UserModel
                {
                    UserFirstName = registerUserDto.UserFirstName,
                    UserLastName = registerUserDto.UserLastName,
                    UserGender = registerUserDto.UserGender,
                    UserIDNumber = registerUserDto.UserIDNumber,
                    UserPassword = registerUserDto.UserPassword,
                    UserAddress = registerUserDto.UserAddress,
                    UserCity = registerUserDto.UserCity,
                    UserEmailAddress = registerUserDto.UserEmailAddress,
                    UserPhoneNumber = registerUserDto.UserPhoneNumber,
                    UserEmergencyContact = registerUserDto.UserEmergencyContact,
                    UserRole = registerUserDto.UserRole
                };

                //  Check if user already exists by IDNumber or Email
                var existingUser = await _dbContext.Users
                    .FirstOrDefaultAsync(u => u.UserIDNumber == registerUserDto.UserIDNumber || u.UserEmailAddress == registerUserDto.UserEmailAddress);

                if (existingUser != null)
                {
                    response.IsSuccess = false;
                    response.Message = "User with the same ID number or email already exists.";
                    return response;
                }

                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "User registered successfully.";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"An error occurred: {ex.Message}";
            }

            return response;
        }

        public Task<ResponseDto?> UpdateUserAsync(UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
