﻿using Microsoft.Extensions.Logging;
using BECapstoneFitFlex.DTOs;
using BECapstoneFitFlex.Models;
namespace BECapstoneFitFlex.Interfaces
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetTagsAsync();
        Task<Tag> GetTagByIdAsync(int id);
        Task<Tag> PostEventAsync(CreateTagDTO tag);
        Task<Tag> UpdateEventAsync(int id, UpdateTagDTO newTag);
        Task<Tag> DeleteEventAsync(int id);
    }
}