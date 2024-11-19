using BECapstoneFitFlex.Interfaces;
using BECapstoneFitFlex.Models;
using BECapstoneFitFlex.DTOs;
namespace BECapstoneFitFlex.Endpoints
{
    public static class ExerciseEndpoints
    {
        public static async void MapExerciseEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/exercise").WithTags(nameof(Exercise));

            group.MapGet("/", async (IExerciseService exerciseService) =>
            {
                return await exerciseService.GetExercisesAsync();
            })
                .WithName("GetExercises")
                .WithOpenApi()
                .Produces<List<Exercise>>(StatusCodes.Status200OK);

            group.MapGet("/exercise/{id}", async (IExerciseService exerciseService, int id) =>
            {
                var exercise = await exerciseService.GetExerciseByIdAsync(id);
                return Results.Ok(exercise);
            })
                .WithName("GetExerciseById")
                .WithOpenApi()
                .Produces<Exercise>(StatusCodes.Status200OK);

            group.MapPost("/", async (IExerciseService exerciseService, CreateExerciseDTO exerciseDTO) =>
            {
                var exercise = await exerciseService.PostExerciseAsync(exerciseDTO);
                return Results.Created($"/exercise/{exercise.Id}", exercise);
            })
                .WithName("PostExercise")
                .WithOpenApi()
                .Produces<Exercise>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest);

            group.MapPut("/{id}", async (IExerciseService exerciseService, int id, UpdateExerciseDTO exerciseDTO) =>
            {
                var exercise = await exerciseService.UpdateExerciseAsync(id, exerciseDTO);
                return Results.Ok(exercise);
            })
                .WithName("UpdateExercise")
                .WithOpenApi()
                .Produces<Exercise>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status204NoContent);

            group.MapDelete("/{id}", async (IExerciseService exerciseService, int id) =>
            {
                var exercise = await exerciseService.DeleteExerciseAsync(id);
                return Results.NoContent();
            })
                .WithName("DeleteExercise")
                .WithOpenApi()
                .Produces<Exercise>(StatusCodes.Status204NoContent);

        }
    }
}