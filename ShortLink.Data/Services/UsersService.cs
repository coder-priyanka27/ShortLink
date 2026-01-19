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

        public List<User> GetUsers()
        {
            var users = _context.Users.Include(n => n.Urls).ToList();
            return users;
        }
    }
}
