using BECapstoneFitFlex.Interfaces;
using BECapstoneFitFlex.Models;
using BECapstoneFitFlex.DTOs;
using BECapstoneFitFlex.Repositories;

namespace BECapstoneFitFlex.Services
{
    public class UserServices : IUserService
    {
        private readonly IUserRepository _userServicesRepo;

        public UserServices(IUserRepository userServicesRepo)
        {
            _userServicesRepo = userServicesRepo;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userServicesRepo.GetUserByIdAsync(id);

        }

        public async Task<User?> CheckUserAsync(string uid)
        {
            return await _userServicesRepo.CheckUserAsync(uid);
        }

        public async Task<User> RegisterUserAsync(User newUser)
        {
            return await _userServicesRepo.RegisterUserAsync(newUser);
        }

        public async Task<User> PostUserAsync(CreateUserDTO userDTO)
        {
            return await _userServicesRepo.PostUserAsync(userDTO);
        }

        public async Task<User> UpdateUserAsync(int id, UpdateUserDTO userDTO)
        {
            return await _userServicesRepo.UpdateUserAsync(id, userDTO);
        }
        public async Task<User> DeleteUserAsync(int id)
        {
            return await _userServicesRepo.DeleteUserAsync(id);
        }
    }
}
