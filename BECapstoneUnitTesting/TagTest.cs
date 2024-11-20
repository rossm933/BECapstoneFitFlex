using Moq;
using BECapstoneFitFlex.Interfaces;
using BECapstoneFitFlex.Models;
using BECapstoneFitFlex.DTOs;
using BECapstoneFitFlex.Services;


namespace BECapstoneUnitTesting
{
    public class TagTest
    {
        private readonly Mock<ITagRepository> _mockTagRepository;
        private readonly ITagService _tagService;

        public TagTest()
        {
            _mockTagRepository = new Mock<ITagRepository>();
            _tagService = new TagServices(_mockTagRepository.Object);

        }
        [Fact]
        public async Task GetTagAsync_WhenCalled_ReturnsTagsAsync()
        {
            var tags = new List<Tag>
            {
                new Tag { Id = 1 },
                new Tag { Id = 2 }

            };

            _mockTagRepository.Setup(x => x.GetTagsAsync()).ReturnsAsync(tags);

            var result = await _tagService.GetTagsAsync();
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task CreateTagAsync_WhenCalled_ReturnNewTagAsync()
        {
            var tagDTO = new CreateTagDTO
            {
                Name = "string",
                UserId = 1,
            };

            var tagItem = new Tag
            {
                Name = tagDTO.Name,
                UserId = tagDTO.UserId,
            };
            _mockTagRepository.Setup(x => x.PostTagAsync(tagDTO)).ReturnsAsync(tagItem);

            var result = await _tagService.PostTagAsync(tagDTO);
            Assert.NotNull(result);
            Assert.Equal(tagDTO.Name, result.Name);
            Assert.Equal(tagDTO.UserId, result.UserId);
        }

        [Fact]
        public async Task UpdateTagAsync_ShouldReturnUpdatedTag_WhenTagExists()
        {
            int tagId = 1;

            var tagItem = new Tag
            {
                Name = "string",
                UserId = 1,
            };
            
            var editTagDTO = new UpdateTagDTO
            {
               Name = "string1",
            };

            var updatedTag = new Tag
            {
                Name = editTagDTO.Name,

            };

            
            _mockTagRepository.Setup(r => r.UpdateTagAsync(tagId, editTagDTO)).ReturnsAsync(updatedTag);

            var result = await _tagService.UpdateTagAsync(tagId, editTagDTO);

            Assert.NotNull(result);
            Assert.Equal(editTagDTO.Name, result.Name);
        }

        [Fact]
        public async Task DeleteTagAsync_WhenCalledWithValidId_DeletesTagAsync()
        {

            var tagId = 1;

            _mockTagRepository.Setup(x => x.DeleteTagAsync(tagId));


            await _tagService.DeleteTagAsync(tagId);


            _mockTagRepository.Verify(x => x.DeleteTagAsync(tagId), Times.Once);
        }
    }
}
