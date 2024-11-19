using BECapstoneFitFlex.Interfaces;
using BECapstoneFitFlex.Models;
using BECapstoneFitFlex.DTOs;

namespace BECapstoneFitFlex.Services
{
    public class TagServices : ITagService
    {
        private readonly ITagRepository _tagServicesRepo;

        public TagServices(ITagRepository tagServicesRepo)
        {
            _tagServicesRepo = tagServicesRepo;
        }

        public async Task<List<Tag>> GetTagsAsync()
        {
            return await _tagServicesRepo.GetTagsAsync();
        }

        public async Task<Tag> PostTagAsync(CreateTagDTO tag)
        {
            return await _tagServicesRepo.PostTagAsync(tag);

        }

        public async Task<Tag> UpdateTagAsync(int id, UpdateTagDTO tag)
        {
            return await _tagServicesRepo.UpdateTagAsync(id, tag);

        }
        public async Task<Tag> DeleteTagAsync(int id)
        {
            return await _tagServicesRepo.DeleteTagAsync(id);
        }
    }
}
