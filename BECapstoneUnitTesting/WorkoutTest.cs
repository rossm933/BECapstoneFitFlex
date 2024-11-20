using Moq;
using BECapstoneFitFlex.Interfaces;
using BECapstoneFitFlex.Models;
using BECapstoneFitFlex.DTOs;
using BECapstoneFitFlex.Services;

namespace BECapstoneUnitTesting
{
    public class WorkoutTest
    {
        private readonly Mock<IWorkoutRepository> _mockWorkoutRepository;
        private readonly IWorkoutService _workoutService;

        public WorkoutTest()
        {
            _mockWorkoutRepository = new Mock<IWorkoutRepository>();
            _workoutService = new WorkoutServices(_mockWorkoutRepository.Object);
        }

        [Fact]
        public async Task GetWorkoutByUserAsync_ShouldReturnUserWorkout_WhenUserWorkoutExist()
        {
            var firstUserId = 1;
            var secondUserId = 2;

            var workoutItem = new List<Workout>
            {
                new Workout { Id = 1, UserId = 1 },
                new Workout { Id = 2, UserId = 2 },
            };

            _mockWorkoutRepository.Setup(v => v.GetWorkoutsByUserAysnc(firstUserId)).ReturnsAsync(workoutItem.Where(v => v.UserId == firstUserId).ToList());
            _mockWorkoutRepository.Setup(v => v.GetWorkoutsByUserAysnc(secondUserId)).ReturnsAsync(workoutItem.Where(v => v.UserId == secondUserId).ToList());

            var firstUserResult = await _workoutService.GetWorkoutsUserAysnc(firstUserId);
            var secondUserResult = await _workoutService.GetWorkoutsUserAysnc(secondUserId);

            Assert.NotNull(firstUserResult);
            Assert.Equal(1, firstUserResult.Count);
            Assert.NotNull(secondUserResult);
            Assert.Single(secondUserResult);

            Assert.All(firstUserResult, workoutItem => Assert.Equal(firstUserId, workoutItem.UserId));
            Assert.All(secondUserResult, workoutItem => Assert.Equal(secondUserId, workoutItem.UserId));

        }
        [Fact]
        public async Task GetWorkoutByIdAsync_WhenCalledWithValidId_ReturnsWorkoutAsync()
        {
            var workoutId = 1;
            var workoutItem = new Workout { Id = workoutId };

            _mockWorkoutRepository.Setup(x => x.GetWorkoutByIdAsync(workoutId)).ReturnsAsync(workoutItem);

            var result = await _workoutService.GetWorkoutByIdAsync(workoutId);

            Assert.NotNull(result);
            Assert.Equal(workoutId, result.Id);
        }
        [Fact]

        public async Task CreateWorkoutAsync_WhenCalled_ReturnNewWorkoutAsync()
        {
            var workoutDTO = new CreateWorkoutDTO
            {
                DateCreated = DateTime.Now,
                WorkoutName = "string",
                Description = "string",
                UserId = 1,
            };

            var workoutItem = new Workout
            {
                DateCreated = workoutDTO.DateCreated,
                WorkoutName = workoutDTO.WorkoutName,
                Description = workoutDTO.Description,
                UserId = workoutDTO.UserId,
            };
            _mockWorkoutRepository.Setup(x => x.PostWorkoutAsync(workoutDTO)).ReturnsAsync(workoutItem);

            var result = await _workoutService.PostWorkoutAsync(workoutDTO);
            Assert.NotNull(result);
            Assert.Equal(workoutDTO.DateCreated, result.DateCreated);
            Assert.Equal(workoutDTO.WorkoutName, result.WorkoutName);
            Assert.Equal(workoutDTO.Description, result.Description);
            Assert.Equal(workoutDTO.UserId, result.UserId);
        }
        [Fact]

        public async Task UpdateWorkoutAsync_WhenCalled_ReturnUpdateWorkoutAsync()
        {
            int workoutId = 1;

            var workoutItem = new Workout
            {
                DateCreated = DateTime.Now,
                WorkoutName = "string",
                Description = "string",
                UserId = 1,

            };

            var editWorkoutDTO = new UpdateWorkoutDTO
            {
                WorkoutName = "string1",
                Description = "string2",

            };

            var updatedWorkout = new Workout
            {
                WorkoutName = editWorkoutDTO.WorkoutName,
                Description = editWorkoutDTO.Description,
            };

            _mockWorkoutRepository.Setup(x => x.GetWorkoutByIdAsync(workoutId)).ReturnsAsync(workoutItem);
            _mockWorkoutRepository.Setup(x => x.UpdateWorkoutAsync(workoutId, editWorkoutDTO)).ReturnsAsync(updatedWorkout);

            var result = await _workoutService.UpdateWorkoutAsync(workoutId, editWorkoutDTO);

            Assert.NotNull(result);
            Assert.Equal(editWorkoutDTO.WorkoutName, result.WorkoutName);
            Assert.Equal(editWorkoutDTO.Description, result.Description);

        }
        [Fact]
        public async Task DeleteWorkoutAsync_WhenCalledWithValidId_DeletesWorkoutAsync()
        {

            var workoutId = 1;

            _mockWorkoutRepository.Setup(x => x.DeleteWorkoutAsync(workoutId));


            await _workoutService.DeleteWorkoutAsync(workoutId);


            _mockWorkoutRepository.Verify(x => x.DeleteWorkoutAsync(workoutId), Times.Once);
        }
    }
}
