using System;
using BECapstoneFitFlex.DTOs;
using BECapstoneFitFlex.Models;
namespace BECapstoneFitFlex.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> PostUserAsync(CreateUserDTO userDTO);
        Task<User> UpdateUserAsync(int id, UpdateUserDTO userDTO);
        Task<User> DeleteUserAsync(int id);
    }
}
