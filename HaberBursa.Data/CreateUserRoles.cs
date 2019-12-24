using HaberBursa.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HaberBursa.Data
{
    public class CreateUserRoles : ICreateUserRoles
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateUserRoles(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public void AddUserRole()
        {

            if (_db.Roles.Any(r => r.Name == "Admin")) return;

            _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole("Kullanici")).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole("Yazar")).GetAwaiter().GetResult();



            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "furkanbrs7@gmail.com",
                Email = "furkanbrs7@gmail.com",
                EmailConfirmed = true,
                FirstName = "Furkan",
                LastName = "Kuzu"
            }, "Kuzu1234*").GetAwaiter().GetResult();

            ApplicationUser user = _db.ApplicationUser.Where
                (u => u.Email == "furkanbrs7@gmail.com").FirstOrDefault();

            _userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();
        }
    }
}
