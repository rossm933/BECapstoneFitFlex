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


        public async Task<List<Workout>> GetWorkoutsAysnc()
        {
            return await _context.Workout
                .Include(w => w.Exercise)
                .OrderBy(w => w.DateCreated)
                .ToListAsync();
        }
        public async Task<Workout> GetWorkoutByIdAsync(int id)
        {
            return await _context.Workout
                .Include(w => w.Exercise)
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
            
            _context.Workout.Add(newWorkout);
            await _context.SaveChangesAsync();
            return newWorkout;
        }

        public async Task<Workout> UpdateWorkoutAsync(int id, UpdateWorkoutDTO workoutDTO)
        {
            var workoutToUpdate = await _context.Workout.SingleOrDefaultAsync(w => w.Id == id);

            if (workoutToUpdate == null)
            {
                return null;
            }

            workoutToUpdate.WorkoutName = workoutDTO.WorkoutName;
            workoutToUpdate.Description = workoutDTO.Description;
            workoutToUpdate.UserId = workoutDTO.UserId;

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
