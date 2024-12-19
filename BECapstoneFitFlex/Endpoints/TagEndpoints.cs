using BECapstoneFitFlex.Interfaces;
using BECapstoneFitFlex.Models;
using BECapstoneFitFlex.DTOs;
using System.Runtime.CompilerServices;
using BECapstoneFitFlex.Services;
namespace BECapstoneFitFlex.Endpoints
{
    public static class TagEndpoints
    {
        public static void MapTagEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/tag").WithTags(nameof(Tag));

            group.MapGet("/", async (ITagService tagService) =>
            {
                return await tagService.GetTagsAsync();
            })
                .WithName("GetTags")
                .WithOpenApi()
                .Produces<List<Tag>>(StatusCodes.Status200OK);

            group.MapGet("/{id}", async (ITagService tagService, int id) =>
            {
                var tag = await tagService.GetTagByIdAsync(id);
                return Results.Ok(tag);
            })
                .WithName("GetTagById")
                .WithOpenApi()
                .Produces<Tag>(StatusCodes.Status200OK);

            group.MapPost("/", async (ITagService tagService, CreateTagDTO tag) =>
            {
                var newTag = await tagService.PostTagAsync(tag);
                return Results.Created($"/tag/{newTag.Id}", newTag);
            })
                .WithName("PostTag")
                .WithOpenApi()
                .Produces<Tag>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest);

            group.MapPut("/{id}", async (ITagService tagService, int id, UpdateTagDTO tag) => 
            { 
                var updatedTag = await tagService.UpdateTagAsync(id, tag);
                return Results.Ok(updatedTag);
            })
                .WithName("UpdatedTag")
                .WithOpenApi()
                .Produces<Tag>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status204NoContent);

            group.MapDelete("/{id}", async (ITagService tagService, int id) =>
            {
                var tag = await tagService.DeleteTagAsync(id);
                return Results.NoContent();
            })

                .WithName("DeleteTag")
                .WithOpenApi()
                .Produces<Tag>(StatusCodes.Status204NoContent);
        }
    }
}
