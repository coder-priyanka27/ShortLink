using Microsoft.EntityFrameworkCore;
using ShortLink.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Data.Services
{
    public class UsersService : IUsersService
    {
        private AppDbContext _context;
        public UsersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AppUser> GetByIdAsync(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(n => n.Id == id);
            return user;
        }

        public async Task<List<AppUser>> GetUsersAsync()
        {
            var users = await _context.Users.Include(n => n.Urls).ToListAsync();
            return users;
        }
        

    }
}
