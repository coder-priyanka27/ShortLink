using ShortLink.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Data.Services
{
    public interface IUsersService
    {
        List<User> GetUsers();
    }
}
