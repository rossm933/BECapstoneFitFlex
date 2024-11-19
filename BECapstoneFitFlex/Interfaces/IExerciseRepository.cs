using BECapstoneFitFlex.DTOs;
using BECapstoneFitFlex.Models;
using Microsoft.Extensions.Logging;
namespace BECapstoneFitFlex.Interfaces
{
    public interface IExerciseRepository
    {
        Task<List<Exercise>> GetExercisesAsync();
        Task<Exercise> GetExerciseByIdAsync(int id);
        Task<Exercise> PostExerciseAsync(CreateExerciseDTO exerciseDTO);
        Task<Exercise> UpdateExerciseAsync(int id, UpdateExerciseDTO exerciseDTO);
        Task<Exercise> DeleteExerciseAsync(int id);
    }
}
