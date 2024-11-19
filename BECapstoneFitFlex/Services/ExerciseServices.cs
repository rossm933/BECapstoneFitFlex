using BECapstoneFitFlex.Interfaces;
using BECapstoneFitFlex.Models;
using BECapstoneFitFlex.DTOs;

namespace BECapstoneFitFlex.Services
{
    public class ExerciseServices : IExerciseService
    {
        private readonly IExerciseRepository _exerciseServicesRepo;

        public ExerciseServices(IExerciseRepository exerciseServicesRepo)
        {
            _exerciseServicesRepo = exerciseServicesRepo;
        }

        public async Task<List<Exercise>> GetExercisesAsync()
        {
            return await _exerciseServicesRepo.GetExercisesAsync();
        }

        public async Task<Exercise> GetExerciseByIdAsync(int id)
        {
            return await _exerciseServicesRepo.GetExerciseByIdAsync(id);
        }

        public async Task<Exercise> PostExerciseAsync(CreateExerciseDTO exerciseDTO)
        {
            return await _exerciseServicesRepo.PostExerciseAsync(exerciseDTO);
        }

        public async Task<Exercise> UpdateExerciseAsync(int id, UpdateExerciseDTO exerciseDTO)
        {
            return await _exerciseServicesRepo.UpdateExerciseAsync(id, exerciseDTO);
        }

        public async Task<Exercise> DeleteExerciseAsync(int id)
        {
            return await _exerciseServicesRepo.DeleteExerciseAsync(id);
        }
    }
}
