using Microsoft.Extensions.Logging;
using BECapstoneFitFlex.DTOs;
using BECapstoneFitFlex.Models;
namespace BECapstoneFitFlex.Interfaces
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetTagsAsync();
        Task<Tag> PostTagAsync(CreateTagDTO tag);
        Task<Tag> UpdateTagAsync(int id, UpdateTagDTO tag);
        Task<Tag> DeleteTagAsync(int id);
    }
}
