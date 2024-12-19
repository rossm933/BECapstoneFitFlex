using Microsoft.EntityFrameworkCore;
using BECapstoneFitFlex.Interfaces;
using BECapstoneFitFlex.Models;
using BECapstoneFitFlex.Data;
using BECapstoneFitFlex.DTOs;

namespace BECapstoneFitFlex.Repositories
{
    public class UserRepository :IUserRepository
    {
        private readonly FitFlexDbContext _context;

        public UserRepository(FitFlexDbContext context)
        {
            _context = context;
        }
        public async Task<User?> CheckUserAsync(string uid)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Uid == uid);
        }
        public async Task<User> RegisterUserAsync(User newUser)
        {
            var registerUser = new User
            {
                Name = newUser.Name,
                Email = newUser.Email,
                Password = newUser.Password,
                ImageUrl = newUser.ImageUrl

            };
            await _context.User.AddAsync(registerUser);
            await _context.SaveChangesAsync();
            return registerUser;
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.User
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> PostUserAsync(CreateUserDTO userDTO)
        {
            var newUser = new User
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Password = userDTO.Password,
                ImageUrl = userDTO.ImageUrl,
                Uid = userDTO.Uid,

            };

            _context.User.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> UpdateUserAsync(int id, UpdateUserDTO userDTO)
        {
            var userToUpdate = await _context.User.FirstOrDefaultAsync(u => u.Id == id);

            if (userToUpdate == null)
            {
                return null;
            }

            userToUpdate.Name = userDTO.Name;
            userToUpdate.Email = userDTO.Email;
            userToUpdate.Password = userDTO.Password;
            userToUpdate.ImageUrl = userDTO.ImageUrl;

            await _context.SaveChangesAsync();
            return userToUpdate;

        }
        public async Task<User> DeleteUserAsync(int id)
        {
            var deleteUser = await _context.User.FirstOrDefaultAsync(u => u.Id == id);

            if (deleteUser == null)
            {
                return null;
            }

            _context.User.Remove(deleteUser);
            await _context.SaveChangesAsync();
            return deleteUser;
        }

    }
}
