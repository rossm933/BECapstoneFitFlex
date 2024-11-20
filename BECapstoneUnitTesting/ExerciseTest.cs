using Moq;
using BECapstoneFitFlex.Interfaces;
using BECapstoneFitFlex.Models;
using BECapstoneFitFlex.DTOs;
using BECapstoneFitFlex.Services;

namespace BECapstoneUnitTesting
{
    public class ExerciseTest
    {
        private readonly Mock<IExerciseRepository> _mockExerciseRepository;
        private readonly IExerciseService _exerciseService;

        public ExerciseTest()
        {
            _mockExerciseRepository = new Mock<IExerciseRepository>();
            _exerciseService = new ExerciseServices(_mockExerciseRepository.Object);
        }

        [Fact]
        public async Task GetExerciseAsync_WhenCalled_ReturnsExercisesAsync()
        {
            var exercise = new List<Exercise>
            {
                new Exercise { Id = 1 },
                new Exercise { Id = 2 }

            };
            _mockExerciseRepository.Setup(x => x.GetExercisesAsync()).ReturnsAsync(exercise);

            var result = await _exerciseService.GetExercisesAsync();
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
        [Fact]
        public async Task GetExerciseByIdAsync_WhenCalledWithValidId_ReturnsExerciseAsync()
        {
            var exerciseId = 1;
            var exerciseItem = new Exercise { Id = exerciseId };

            _mockExerciseRepository.Setup(x => x.GetExerciseByIdAsync(exerciseId)).ReturnsAsync(exerciseItem);

            var result = await _exerciseService.GetExerciseByIdAsync(exerciseId);

            Assert.NotNull(result);
            Assert.Equal(exerciseId, result.Id);
        }
        [Fact]

        public async Task CreateExerciseAsync_WhenCalled_ReturnNewExerciseAsync()
        {
            var exerciseDTO = new CreateExerciseDTO
            {
                ExerciseName = "string",
                Description = "string",
                Repetitions = 10,
                ImageUrl = "string",
                Sets = 3,
                Weight = 12.00m,
                UserId = 1,

            };

            var exerciseItem = new Exercise
            {
                ExerciseName = exerciseDTO.ExerciseName,
                Description = exerciseDTO.Description,
                Repetitions = exerciseDTO.Repetitions,
                ImageUrl = exerciseDTO.ImageUrl,
                Sets = exerciseDTO.Sets,
                Weight = exerciseDTO.Weight,
                UserId = exerciseDTO.UserId,
            };
            _mockExerciseRepository.Setup(x => x.PostExerciseAsync(exerciseDTO)).ReturnsAsync(exerciseItem);

            var result = await _exerciseService.PostExerciseAsync(exerciseDTO);
            Assert.NotNull(result);
            Assert.Equal(exerciseDTO.ExerciseName, result.ExerciseName);
            Assert.Equal(exerciseDTO.Description, result.Description);
            Assert.Equal(exerciseDTO.Repetitions, result.Repetitions);
            Assert.Equal(exerciseDTO.ImageUrl, result.ImageUrl);
            Assert.Equal(exerciseDTO.Sets, result.Sets);
            Assert.Equal(exerciseDTO.Weight, result.Weight);
            Assert.Equal(exerciseDTO.UserId, result.UserId);
        }
        [Fact]

        public async Task UpdateExerciseAsync_WhenCalled_ReturnUpdateExerciseAsync()
        {
            int exerciseId = 1;

            var exerciseItem = new Exercise
            {
                ExerciseName = "string",
                Description = "string",
                Repetitions = 10,
                ImageUrl = "string",
                Sets = 3,
                Weight = 12.00m,
                UserId = 1,

            };

            var editExerciseDTO = new UpdateExerciseDTO
            {
                ExerciseName = "string1",
                Description = "string2",
                Repetitions = 8,
                ImageUrl = "string3",
                Sets = 4,
                Weight = 14.00m,

            };

            var updatedExercise = new Exercise
            {

                ExerciseName = editExerciseDTO.ExerciseName,
                Description = editExerciseDTO.Description,
                Repetitions = editExerciseDTO.Repetitions,
                ImageUrl = editExerciseDTO.ImageUrl,
                Sets = editExerciseDTO.Sets,
                Weight = editExerciseDTO.Weight,
            };

            _mockExerciseRepository.Setup(x => x.GetExerciseByIdAsync(exerciseId)).ReturnsAsync(exerciseItem);
            _mockExerciseRepository.Setup(x => x.UpdateExerciseAsync(exerciseId, editExerciseDTO)).ReturnsAsync(updatedExercise);

            var result = await _exerciseService.UpdateExerciseAsync(exerciseId, editExerciseDTO);

            Assert.NotNull(result);
            Assert.Equal(editExerciseDTO.ExerciseName, result.ExerciseName);
            Assert.Equal(editExerciseDTO.Description, result.Description);
            Assert.Equal(editExerciseDTO.Repetitions, result.Repetitions);
            Assert.Equal(editExerciseDTO.ImageUrl, result.ImageUrl);
            Assert.Equal(editExerciseDTO.Sets, result.Sets);
            Assert.Equal(editExerciseDTO.Weight, result.Weight);

        }
        [Fact]
        public async Task DeleteExerciseAsync_WhenCalledWithValidId_DeletesExerciseAsync()
        {

            var exerciseId = 1;

            _mockExerciseRepository.Setup(x => x.DeleteExerciseAsync(exerciseId));


            await _exerciseService.DeleteExerciseAsync(exerciseId);


            _mockExerciseRepository.Verify(x => x.DeleteExerciseAsync(exerciseId), Times.Once);
        }
    }
}