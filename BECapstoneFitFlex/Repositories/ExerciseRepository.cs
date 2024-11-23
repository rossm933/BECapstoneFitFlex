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
            // Create the base Exercise entity
            var newExercise = new Exercise
            {
                ExerciseName = exerciseDTO.ExerciseName,
                Description = exerciseDTO.Description,
                Repetitions = exerciseDTO.Repetitions,
                ImageUrl = exerciseDTO.ImageUrl,
                Sets = exerciseDTO.Sets,
                Weight = exerciseDTO.Weight,
                UserId = exerciseDTO.UserId,
            };

            // Create ExerciseTag relationships if TagIds are provided
            if (exerciseDTO.TagIds != null && exerciseDTO.TagIds.Any())
            {
                newExercise.ExerciseTag = exerciseDTO.TagIds
                    .Select(tagId => new ExerciseTag { TagId = tagId })
                    .ToList();
            }

            // Add the new exercise to the database
            _context.Exercise.Add(newExercise);
            await _context.SaveChangesAsync();

            return newExercise;
        }


        public async Task<Exercise> UpdateExerciseAsync(int id, UpdateExerciseDTO exerciseDTO)
        {
            // Fetch the exercise and include the ExerciseTag relationship
            var exerciseToUpdate = await _context.Exercise
                .Include(e => e.ExerciseTag)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (exerciseToUpdate == null)
            {
                return null;
            }

            // Update scalar properties
            exerciseToUpdate.ExerciseName = exerciseDTO.ExerciseName;
            exerciseToUpdate.Description = exerciseDTO.Description;
            exerciseToUpdate.Repetitions = exerciseDTO.Repetitions;
            exerciseToUpdate.ImageUrl = exerciseDTO.ImageUrl;
            exerciseToUpdate.Sets = exerciseDTO.Sets;
            exerciseToUpdate.Weight = exerciseDTO.Weight;

            // Update ExerciseTag relationships
            var existingTags = exerciseToUpdate.ExerciseTag ?? new List<ExerciseTag>();

            // Remove tags not in the new TagIds list
            _context.ExerciseTag.RemoveRange(
                existingTags.Where(et => !exerciseDTO.TagIds.Contains(et.TagId))
            );

            // Add new tags that don't already exist
            var newTags = exerciseDTO.TagIds
                .Where(tagId => !existingTags.Any(et => et.TagId == tagId))
                .Select(tagId => new ExerciseTag { ExerciseId = id, TagId = tagId });

            await _context.ExerciseTag.AddRangeAsync(newTags);

            // Save changes
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
