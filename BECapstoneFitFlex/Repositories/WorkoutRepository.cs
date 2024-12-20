using Microsoft.EntityFrameworkCore;
using BECapstoneFitFlex.Interfaces;
using BECapstoneFitFlex.Models;
using BECapstoneFitFlex.Data;
using BECapstoneFitFlex.DTOs;

namespace BECapstoneFitFlex.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly FitFlexDbContext _context;

        public WorkoutRepository(FitFlexDbContext context)
        {
            _context = context;
        }


        public async Task<List<Workout>> GetWorkoutsByUserAysnc(int userId)
        {
            return await _context.Workout
                .Include(e => e.ExerciseWorkout)
                .ThenInclude(s => s.Exercise)
                .Where(w => w.UserId == userId)
                .OrderBy(w => w.DateCreated)
                .ToListAsync();
        }
        public async Task<Workout> GetWorkoutByIdAsync(int id)
        {
            return await _context.Workout
                .Include(e => e.ExerciseWorkout)
                .ThenInclude(s => s.Exercise)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Workout> PostWorkoutAsync(CreateWorkoutDTO workoutDTO)
        {
            var newWorkout = new Workout
            {
                DateCreated = workoutDTO.DateCreated,
                WorkoutName = workoutDTO.WorkoutName,
                Description = workoutDTO.Description,
                UserId = workoutDTO.UserId,

            };
           
            if (workoutDTO.ExerciseIds != null && workoutDTO.ExerciseIds.Any())
            {
                newWorkout.ExerciseWorkout = workoutDTO.ExerciseIds
                    .Select(exerciseId => new ExerciseWorkout { ExerciseId = exerciseId })
                    .ToList();
            }

            _context.Workout.Add(newWorkout);
            await _context.SaveChangesAsync();
            return newWorkout;
        }

        public async Task<Workout> UpdateWorkoutAsync(int id, UpdateWorkoutDTO workoutDTO)
        {
            // Fetch the workout and include the ExerciseWorkout relationships
            var workoutToUpdate = await _context.Workout
                .Include(e => e.ExerciseWorkout)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (workoutToUpdate == null)
            {
                return null;
            }

            // Update workout details
            workoutToUpdate.WorkoutName = workoutDTO.WorkoutName;
            workoutToUpdate.Description = workoutDTO.Description;
            workoutToUpdate.UserId = workoutDTO.UserId;

            // Update ExerciseWorkout relationships
            var existingExercises = workoutToUpdate.ExerciseWorkout ?? new List<ExerciseWorkout>();

            // Remove exercises not in the new ExerciseIds list
            _context.ExerciseWorkout.RemoveRange(
                existingExercises.Where(et => !workoutDTO.ExerciseIds.Contains(et.ExerciseId))
            );

            // Add new exercises that don't already exist
            var newExercises = workoutDTO.ExerciseIds
                .Where(exerciseId => !existingExercises.Any(et => et.ExerciseId == exerciseId))
                .Select(exerciseId => new ExerciseWorkout { WorkoutId = id, ExerciseId = exerciseId });

            await _context.ExerciseWorkout.AddRangeAsync(newExercises);

            // Save changes to the database
            await _context.SaveChangesAsync();

            return workoutToUpdate;
        }
        public async Task<Workout> DeleteWorkoutAsync(int id)
        {
            var deleteWorkout = await _context.Workout.SingleOrDefaultAsync(w => w.Id == id);

            if (deleteWorkout == null)
            { 
                return null;
            }

            _context.Workout.Remove(deleteWorkout);
            await _context.SaveChangesAsync();
            return deleteWorkout;
        }
    }
}
