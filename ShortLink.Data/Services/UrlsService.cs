using Microsoft.EntityFrameworkCore;
using ShortLink.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Data.Services
{
    public class UrlsService : IUrlsService
    {
        private AppDbContext _context;
        public UrlsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Url> GetByIdAsync(int id)
        {
            var url = await _context.Urls.FirstOrDefaultAsync(u => u.Id == id);
            return url;
        }

        public async Task<List<Url>> GetUrlsAsync(string userId, bool isAdmin)
        {
            var allUrlsQuery = _context.Urls.Include(n => n.User);

            if (isAdmin)
            {
                return await allUrlsQuery.ToListAsync();
            }
            else
            {
                return await allUrlsQuery.Where(n => n.UserId == userId).ToListAsync();
            }
        }
        public async Task<Url> AddAsync(Url url)
        {
            await _context.Urls.AddAsync(url);
            await _context.SaveChangesAsync();
            return url;
        }
        public async Task<Url> UpdateAsync(int id, Url url)
        {
            var urlDb = await _context.Urls.FirstOrDefaultAsync(n => n.Id == id);

            if (urlDb != null)
            {
                urlDb.OriginalLink = url.OriginalLink;
                urlDb.ShortLink = url.ShortLink;
                urlDb.DateUpdated = DateTime.Now;

                await _context.SaveChangesAsync();

            }
            return urlDb;
        }

        public async Task DeleteAsync(int id)
        {
            var urlDb = await _context.Urls.FirstOrDefaultAsync(n => n.Id == id);
            if (urlDb != null)
            {
                _context.Urls.Remove(urlDb);
                await _context.SaveChangesAsync();
            }
        }
    }
}
