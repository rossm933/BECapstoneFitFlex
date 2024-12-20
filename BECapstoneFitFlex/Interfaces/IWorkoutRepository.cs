﻿using BECapstoneFitFlex.DTOs;
using BECapstoneFitFlex.Models;
using Microsoft.Extensions.Logging;
namespace BECapstoneFitFlex.Interfaces
{
    public interface IWorkoutRepository
    {
        Task<List<Workout>> GetWorkoutsByUserAysnc(int userId);
        Task<Workout> GetWorkoutByIdAsync(int id);
        Task<Workout> PostWorkoutAsync(CreateWorkoutDTO workoutDTO);
        Task<Workout> UpdateWorkoutAsync(int id, UpdateWorkoutDTO workoutDTO);
        Task<Workout> DeleteWorkoutAsync(int id);
    }
}
