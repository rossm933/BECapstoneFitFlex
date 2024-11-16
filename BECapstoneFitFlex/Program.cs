
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using BECapstoneFitFlex.Data;

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

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors();
            app.UseHttpsRedirection();

            app.Run();
        }
    }
}
