using BECapstoneFitFlex.DTOs;
using BECapstoneFitFlex.Models;
namespace BECapstoneFitFlex.Interfaces
{
    public interface IExerciseService
    {
        Task<List<Exercise>> GetExercisesAsync();
        Task<Exercise> GetExerciseByIdAsync(int id);
        Task<Exercise> PostEventAsync(CreateExerciseDTO exerciseDTO);
        Task<Exercise> UpdateExerciseAsync(int id, UpdateExerciseDTO exerciseDTO);
        Task<Exercise> DeleteExerciseAsync(int id);
    }
}
