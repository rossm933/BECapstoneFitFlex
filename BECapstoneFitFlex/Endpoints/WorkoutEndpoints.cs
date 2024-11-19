using BECapstoneFitFlex.Interfaces;
using BECapstoneFitFlex.Models;
using BECapstoneFitFlex.DTOs;
using Microsoft.Extensions.Logging;
namespace BECapstoneFitFlex.Endpoints
{
    public static class WorkoutEndpoints
    {
        public static void MapWorkoutEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/workout").WithTags(nameof(Workout));

            group.MapGet("/{userId}", async (IWorkoutService workoutService, int userId) =>
            {
                var workout = await workoutService.GetWorkoutsUserAysnc(userId);
                return Results.Ok(workout);

            })
                .WithName("GetWorkoutByUserId")
                .WithOpenApi()
                .Produces<List<Workout>>(StatusCodes.Status200OK);

            group.MapGet("/{id}", async (IWorkoutService workoutService, int id) =>
            {
                var workout = await workoutService.GetWorkoutByIdAsync(id);
                return Results.Ok(workout);
            })
                .WithName("GetWorkoutById")
                .WithOpenApi()
                .Produces<Workout>(StatusCodes.Status200OK);

            group.MapPost("/", async (IWorkoutService workoutService, CreateWorkoutDTO workoutDTO) =>
            {
                var workout = await workoutService.PostWorkoutAsync(workoutDTO);
                return Results.Created($"/workout/{workout.Id}", workout);
            })
                .WithName("PostWorkout")
                .WithOpenApi()
                .Produces<Workout>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest);

            group.MapPut("/{id}", async (IWorkoutService workoutService, int id, UpdateWorkoutDTO workoutDTO) =>
            {
                var workout = await workoutService.UpdateWorkoutAsync(id, workoutDTO);
                return Results.Ok(workout);
            })
                .WithName("UpdateWorkout")
                .WithOpenApi()
                .Produces<Workout>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status204NoContent);

            group.MapDelete("/{id}", async (IWorkoutService workoutService, int id) =>
            {
                var workout = await workoutService.DeleteWorkoutAsync(id);
                return Results.NoContent();
            })

                .WithName("DeleteWorkout")
                .WithOpenApi()
                .Produces<Workout>(StatusCodes.Status204NoContent);
        }
    }
}
