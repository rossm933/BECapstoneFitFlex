using Microsoft.EntityFrameworkCore;
using BECapstoneFitFlex.Interfaces;
using BECapstoneFitFlex.Models;
using BECapstoneFitFlex.Data;
using BECapstoneFitFlex.DTOs;

namespace BECapstoneFitFlex.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly FitFlexDbContext _context;

        public ExerciseRepository (FitFlexDbContext context)
        {
            _context = context;
        }

        public async Task<List<Exercise>> GetExercisesAsync()
        {
            return await _context.Exercise
                .Include(e => e.ExerciseTag)
                .ThenInclude(s => s.Tag)
                .ToListAsync();

        }

        public async Task<Exercise> GetExerciseByIdAsync(int id)
        {
            return await _context.Exercise
                .Include(e => e.ExerciseTag)
                .ThenInclude(s => s.Tag)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Exercise> PostExerciseAsync(CreateExerciseDTO exerciseDTO)
        {
            var newExercise = new Exercise
            {
                ExerciseName = exerciseDTO.ExerciseName,
                Description = exerciseDTO.Description,
                Repetitions = exerciseDTO.Repetitions,
                ImageUrl = exerciseDTO.ImageUrl,
                Sets = exerciseDTO.Sets,
                Weight = exerciseDTO.Weight,
                UserId = exerciseDTO.UserId,
                ExerciseTag = exerciseDTO.ExerciseTag,

            };
            _context.Exercise.Add(newExercise);
            await _context.SaveChangesAsync();
            return newExercise;
        }

        public async Task<Exercise> UpdateExerciseAsync(int id, UpdateExerciseDTO exerciseDTO)
        {
            var exerciseToUpdate = await _context.Exercise
                .Include(e => e.ExerciseTag)
                .FirstOrDefaultAsync (e => e.Id == id);

            if (exerciseToUpdate == null)
            {
                return null;
            }
            
            exerciseToUpdate.ExerciseName = exerciseDTO.ExerciseName;
            exerciseToUpdate.Description = exerciseDTO.Description;
            exerciseToUpdate.Repetitions = exerciseDTO.Repetitions;
            exerciseToUpdate.ImageUrl = exerciseDTO.ImageUrl;
            exerciseToUpdate.Sets = exerciseDTO.Sets;
            exerciseToUpdate.Weight = exerciseDTO.Weight;
            exerciseToUpdate.ExerciseTag = exerciseDTO.ExerciseTag;

            await _context.SaveChangesAsync();
            return exerciseToUpdate;
        }

        public async Task<Exercise> DeleteExerciseAsync(int id)
        {
            var deleteExercise = await _context.Exercise.FirstOrDefaultAsync(e => e.Id == id);

            if (deleteExercise == null)
            {
                return null;
            }

            _context.Exercise.Remove(deleteExercise);
            await _context.SaveChangesAsync();
            return deleteExercise;
        }
    }
}
