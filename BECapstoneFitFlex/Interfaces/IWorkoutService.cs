using BECapstoneFitFlex.DTOs;
using BECapstoneFitFlex.Models;
namespace BECapstoneFitFlex.Interfaces
{
    public interface IWorkoutService
    {
        Task<List<Workout>> GetWorkoutsAysnc();
        Task<Workout> GetWorkoutByIdAsync(int id);
        Task<Workout> PostWorkoutAsync(CreateWorkoutDTO workoutDTO);
        Task<Workout> UpdateWorkoutAsync(int id, UpdateWorkoutDTO workoutDTO);
        Task<Workout> DeleteWorkoutAsync(int id);
    }
}
