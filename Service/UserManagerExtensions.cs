using App.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindByAppLoginAsync(this UserManager<AppUser> _userManager, string AppLogin)
        {
            return await _userManager?.Users?.SingleOrDefaultAsync(x => x.Login == AppLogin);
        }
    }
}
