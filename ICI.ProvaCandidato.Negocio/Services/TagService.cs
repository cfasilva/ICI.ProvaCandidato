using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICI.ProvaCandidato.Dados;
using ICI.ProvaCandidato.Dados.Entities;
using ICI.ProvaCandidato.Negocio.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ICI.ProvaCandidato.Negocio.Services
{
    public class TagService
    {
        private readonly ApplicationDbContext _context;

        public TagService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<TagDto>> List(string searchString)
        {
            var tags = from t in _context.Tags
                       select t;

            if (!string.IsNullOrEmpty(searchString))
            {
                tags = tags.Where(s => s.Description.Contains(searchString));
            }

            var dtos = await tags
                .Select(x => new TagDto()
                {
                    Id = x.Id,
                    Description = x.Description
                })
                .ToListAsync();

            return dtos;
        }

        public async Task Add(TagDto dto)
        {
            var entity = new Tag() { Description = dto.Description };
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TagDto dto)
        {
            var entity = await _context.Tags.FindAsync(dto.Id);
            if (entity != null)
            {
                entity.Description = dto.Description;
                _context.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<TagDto> Find(int id)
        {
            return await _context.Tags
                .Select(x => new TagDto()
                {
                    Id = x.Id,
                    Description = x.Description
                })
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Tags.FindAsync(id);
            if (entity != null)
            {
                if (entity.TagNews.Count > 0)
                {
                    throw new Exception("Could not delete. The tag is linked to a news.");
                }
                _context.Tags.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
