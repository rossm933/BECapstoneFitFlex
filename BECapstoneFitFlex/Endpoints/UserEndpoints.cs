using BECapstoneFitFlex.Interfaces;
using BECapstoneFitFlex.Models;
using BECapstoneFitFlex.DTOs;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
namespace BECapstoneFitFlex.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder routes) 
        {
            var group = routes.MapGroup("/user").WithTags(nameof(User));


            group.MapGet("/checkUser/{uid}", async (IUserService userService, string uid) =>
            {
                var user = await userService.CheckUserAsync(uid);

                if (user == null)
                {
                    return Results.NotFound("user not found");
                }
                return Results.Ok(user);
            });

            group.MapPost("/register", async (IUserService userService, User user) =>
            {
                var newUser = await userService.RegisterUserAsync(user);
                return Results.Created($"/users/{newUser.Id}", newUser);
            });

            group.MapGet("/{id}", async (IUserService userService, int id) =>
            {
                var user = await userService.GetUserByIdAsync(id);
                return Results.Ok(user);
            })
                .WithName("GetUserById")
                .WithOpenApi()
                .Produces<User>(StatusCodes.Status200OK);

            group.MapPost("/", async (IUserService userService, CreateUserDTO userDTO) =>
            {
                var user = await userService.PostUserAsync(userDTO);
                return Results.Created($"/user/{user.Id}", user);
            })
                .WithName("PostUser")
                .WithOpenApi()
                .Produces<User>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest);

            group.MapPut("/{id}", async (IUserService userService, int id, UpdateUserDTO userDTO) => 
            {
                var user = await userService.UpdateUserAsync(id, userDTO);
                return Results.Ok(user);
            })
                .WithName("UpdateUser")
                .WithOpenApi()
                .Produces<User>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status204NoContent);

            group.MapDelete("/{id}", async (IUserService userService, int id) =>
            {
                var user = await userService.DeleteUserAsync(id);
                return Results.NoContent();
            })

                .WithName("DeleteUser")
                .WithOpenApi()
                .Produces<User>(StatusCodes.Status204NoContent);
        }

    }
}
