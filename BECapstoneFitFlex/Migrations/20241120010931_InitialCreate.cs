using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BECapstoneFitFlex.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    WorkoutName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workout_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkoutId = table.Column<int>(type: "integer", nullable: false),
                    ExerciseName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Repetitions = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    Sets = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercise_Workout_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    ExerciseId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExerciseTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TagId = table.Column<int>(type: "integer", nullable: false),
                    ExerciseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseTag_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "ExerciseId", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, null, "Chest", null },
                    { 2, null, "Triceps", null },
                    { 3, null, "Back", null },
                    { 4, null, "Legs", null },
                    { 5, null, "Shoulders", null },
                    { 6, null, "Core", null },
                    { 7, null, "Biceps", null },
                    { 8, null, "Strength", null },
                    { 9, null, "Flexibility", null },
                    { 10, null, "Endurance", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "ImageUrl", "Name", "Password", "Uid" },
                values: new object[,]
                {
                    { 100, "ross.morgan933@gmail.com", "https://avatars.githubusercontent.com/u/148557558?v=4", "Ross Morgan", "password123", null },
                    { 101, "janesmith@example.com", "https://example.com/images/jane_smith.jpg", "Jane Smith", "securepass456", null }
                });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateCreated", "Description", "UserId", "WorkoutName" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1999), "Focus on building upper body strength with weights.", 100, "Strength Training" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1994), "Focus on lower body strength with weights.", 100, "Leg Day" }
                });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Description", "ExerciseName", "ImageUrl", "Repetitions", "Sets", "UserId", "Weight", "WorkoutId" },
                values: new object[,]
                {
                    { 1, "Chest and triceps workout with a barbell.", "Bench Press", "https://www.shutterstock.com/image-illustration/closegrip-barbell-bench-press-3d-600nw-430936051.jpg", 10, 3, 100, 80.5m, 1 },
                    { 2, "Full-body compound exercise.", "Deadlift", "https://www.evolvefitstudios.com/uploads/1/0/2/9/102951852/deadlifts_orig.jpeg", 8, 4, 100, 100m, 2 },
                    { 3, "Lower body strength exercise.", "Squats", "https://static.strengthlevel.com/images/exercises/squat/squat-800.jpg", 12, 3, 100, 60m, 2 },
                    { 4, "Upper body workout targeting back and biceps.", "Pull-Ups", "https://anabolicaliens.com/cdn/shop/articles/199990_400x.png?v=1645089103", 10, 3, 100, 0m, 2 },
                    { 5, "Shoulder strength exercise with a barbell.", "Shoulder Press", "https://static.strengthlevel.com/images/exercises/shoulder-press/shoulder-press-800.jpg", 8, 4, 100, 50m, 1 },
                    { 6, "Core stability exercise.", "Plank", "https://www.inspireusafoundation.org/wp-content/uploads/2023/07/plank-benefits.png", 1, 3, 100, 0m, 1 },
                    { 7, "Isolation exercise for the biceps.", "Bicep Curls", "https://cdn.shopify.com/s/files/1/2384/0833/files/inner-bicep-curl-benefits.jpg?v=1689192787", 12, 3, 100, 15m, 1 },
                    { 8, "Strengthens triceps and shoulders.", "Tricep Dips", "https://pump-app.s3.eu-west-2.amazonaws.com/exercise-assets/17551101-Weighted-Tricep-Dips_Upper-Arms_small.jpg", 12, 3, 100, 0m, 1 }
                });

            migrationBuilder.InsertData(
                table: "ExerciseTag",
                columns: new[] { "Id", "ExerciseId", "TagId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 3 },
                    { 3, 3, 4 },
                    { 5, 1, 2 },
                    { 6, 2, 4 },
                    { 7, 4, 3 },
                    { 8, 4, 7 },
                    { 9, 5, 5 },
                    { 10, 6, 6 },
                    { 11, 7, 7 },
                    { 12, 8, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_UserId",
                table: "Exercise",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_WorkoutId",
                table: "Exercise",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTag_ExerciseId",
                table: "ExerciseTag",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTag_TagId",
                table: "ExerciseTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ExerciseId",
                table: "Tag",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Workout_UserId",
                table: "Workout",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseTag");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Workout");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
