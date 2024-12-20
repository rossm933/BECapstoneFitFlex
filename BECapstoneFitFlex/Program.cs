
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using BECapstoneFitFlex.Data;
using BECapstoneFitFlex.Endpoints;
using BECapstoneFitFlex.Interfaces;
using BECapstoneFitFlex.Repositories;
using BECapstoneFitFlex.Services;

namespace BECapstoneFitFlex
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // allows passing datetimes without time zone data
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // allows our api endpoints to access the database through Entity Framework Core
            builder.Services.AddNpgsql<FitFlexDbContext>(builder.Configuration["FitFlexDbConnectionString"]);

            // Set the JSON serializer options
            builder.Services.Configure<JsonOptions>(options => { options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });

            builder.Services.AddScoped<IWorkoutService, WorkoutServices>();
            builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();
            builder.Services.AddScoped<ITagService, TagServices>();
            builder.Services.AddScoped<ITagRepository, TagRepository>();
            builder.Services.AddScoped<IUserService, UserServices>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IExerciseService, ExerciseServices>();
            builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://localhost:3000")
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }



            app.UseAuthorization();
            app.UseCors();
            app.UseHttpsRedirection();

            app.MapExerciseEndpoints();
            app.MapTagEndpoints();
            app.MapUserEndpoints();
            app.MapWorkoutEndpoints();

            app.Run();
        }
    }
}
