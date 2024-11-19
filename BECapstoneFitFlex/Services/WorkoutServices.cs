using BECapstoneFitFlex.Interfaces;
using BECapstoneFitFlex.Models;
using BECapstoneFitFlex.DTOs;

namespace BECapstoneFitFlex.Services
{
    public class WorkoutServices : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutServicesRepo;

        public WorkoutServices(IWorkoutRepository workoutServicesRepo)
        {
            _workoutServicesRepo = workoutServicesRepo;
        }

        public async Task<List<Workout>> GetWorkoutsUserAysnc(int userId)
        {
            return await _workoutServicesRepo.GetWorkoutsByUserAysnc(userId);
        }

        public async Task<Workout> GetWorkoutByIdAsync(int id)
        {
            return await _workoutServicesRepo.GetWorkoutByIdAsync(id);
        }

        public async Task<Workout> PostWorkoutAsync(CreateWorkoutDTO workoutDTO)
        {
            return await _workoutServicesRepo.PostWorkoutAsync(workoutDTO);
        }

        public async Task<Workout> UpdateWorkoutAsync(int id, UpdateWorkoutDTO workoutDTO)
        {
            return await _workoutServicesRepo.UpdateWorkoutAsync(id, workoutDTO);

        }

        public async Task<Workout> DeleteWorkoutAsync(int id)
        {
            return await _workoutServicesRepo.DeleteWorkoutAsync(id);
        }
    }
}
