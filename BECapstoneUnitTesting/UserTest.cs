using Moq;
using BECapstoneFitFlex.Interfaces;
using BECapstoneFitFlex.Models;
using BECapstoneFitFlex.DTOs;
using BECapstoneFitFlex.Services;
namespace BECapstoneUnitTesting
{
    public class UserTest
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly IUserService _userService;

        public UserTest()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _userService = new UserServices(_mockUserRepository.Object);

        }

        [Fact]
        public async Task GetUserByIdAsync_WhenCalledWithValidId_ReturnsUsersAsync()
        {
            var userId = 1;
            var userItem = new User { Id = userId };

            _mockUserRepository.Setup(x => x.GetUserByIdAsync(userId)).ReturnsAsync(userItem);

            var result = await _userService.GetUserByIdAsync(userId);

            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
        }
        [Fact]
        public async Task RegisterUserAsync_ShouldReturnNewUserId()
        {
            // Arrange
            var newUser = new User
            {
                Id = 2,
                Uid = "qvds941JGQYhQ4DvLi0mxSE0juM2",
                Name = "newUser01",
                Email = "newuser@example.com",
                ImageUrl = "example.jpg",
                Password = "password123"
            };

            //Setup
            _mockUserRepository
                .Setup(repo => repo.RegisterUserAsync(newUser))
                .ReturnsAsync(newUser);

            // Act
            var actualUser = await _userService.RegisterUserAsync(newUser);

            // Assert
            Assert.Equal(newUser.Id, actualUser.Id);
        }

        [Fact]

        public async Task CreateUserAsync_WhenCalled_ReturnNewUserAsync()
        {
            var userDTO = new CreateUserDTO
            {
                Name = "string",
                Email = "string",
                Password = "string",
                ImageUrl = "string",
                Uid = "string",
            };

            var userItem = new User
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Password = userDTO.Password,
                ImageUrl = userDTO.ImageUrl,
                Uid = userDTO.Uid,
            };
            _mockUserRepository.Setup(x => x.PostUserAsync(userDTO)).ReturnsAsync(userItem);

            var result = await _userService.PostUserAsync(userDTO);
            Assert.NotNull(result);
            Assert.Equal(userDTO.Name, result.Name);
            Assert.Equal(userDTO.Email, result.Email);
            Assert.Equal(userDTO.Password, result.Password);
            Assert.Equal(userDTO.Uid, result.Uid);
        }
        [Fact]

        public async Task UpdateUserAsync_WhenCalled_ReturnUpdateUserAsync()
        {
            int userId = 1;

            var userItem = new User
            {
                Name = "string",
                Email = "string",
                Password = "string",
                ImageUrl = "string",
                Uid = "string",

            };

            var editUserDTO = new UpdateUserDTO
            {
                Name = "string1",
                Email = "string2",
                Password = "string3",
                ImageUrl = "string4",

            };

            var updatedUser = new User
            {
                Name = editUserDTO.Name,
                Email = editUserDTO.Email,
                Password = editUserDTO.Password,
                ImageUrl = editUserDTO.ImageUrl,
            };

            _mockUserRepository.Setup(x => x.GetUserByIdAsync(userId)).ReturnsAsync(userItem);
            _mockUserRepository.Setup(x => x.UpdateUserAsync(userId, editUserDTO)).ReturnsAsync(updatedUser);

            var result = await _userService.UpdateUserAsync(userId, editUserDTO);

            Assert.NotNull(result);
            Assert.Equal(editUserDTO.Name, result.Name);
            Assert.Equal(editUserDTO.Email, result.Email);
            Assert.Equal(editUserDTO.Password, result.Password);
            Assert.Equal(editUserDTO.ImageUrl, result.ImageUrl);

        }

        [Fact]
        public async Task DeleteUserAsync_WhenCalledWithValidId_DeletesUserAsync()
        {

            var userId = 1;

            _mockUserRepository.Setup(x => x.DeleteUserAsync(userId));


            await _userService.DeleteUserAsync(userId);


            _mockUserRepository.Verify(x => x.DeleteUserAsync(userId), Times.Once);
        }
    }
}
