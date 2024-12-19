using Microsoft.EntityFrameworkCore;
using BECapstoneFitFlex.Interfaces;
using BECapstoneFitFlex.Models;
using BECapstoneFitFlex.Data;
using BECapstoneFitFlex.DTOs;

namespace BECapstoneFitFlex.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly FitFlexDbContext _context;

        public TagRepository (FitFlexDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tag>> GetTagsAsync()
        {
            return await _context.Tag
                .ToListAsync();
        }

        public async Task<Tag> GetTagByIdAsync(int id)
        {
            return await _context.Tag
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Tag> PostTagAsync(CreateTagDTO tag)
        {
            var newTag = new Tag
            {
                Name = tag.Name,
                UserId = tag.UserId
            };

            _context.Tag.Add(newTag);
            await _context.SaveChangesAsync();
            return newTag;
            
        }

        public async Task<Tag> UpdateTagAsync(int id, UpdateTagDTO tag)
        {
            var tagToUpdate = await _context.Tag.FirstOrDefaultAsync(t => t.Id == id);

            if (tagToUpdate == null)
            {
                return null;
            }

            tagToUpdate.Name = tag.Name;
            await _context.SaveChangesAsync();
            return tagToUpdate;
            
        }

        public async Task<Tag> DeleteTagAsync(int id)
        {
            var deleteTag = await _context.Tag.FirstOrDefaultAsync(t => t.Id == id);

            if (deleteTag == null)
            {
                return null;
            }

            _context.Tag.Remove(deleteTag);
            await _context.SaveChangesAsync();
            return deleteTag;
        }
    }
}
