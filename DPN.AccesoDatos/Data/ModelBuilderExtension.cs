using DPN.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DPN.DataAccess.Data
{
    public static class ModelBuilderExtension 
    {
        public static void Seed(this ModelBuilder builder)
        {
            // Ids are needed
            var adminRoleId = Guid.NewGuid().ToString();
            var memberRoleId = Guid.NewGuid().ToString();
            var adminUserId = Guid.NewGuid().ToString();
            var memberUserId = Guid.NewGuid().ToString();

            var Password = "Admin123*";
            var HashPwd = new PasswordHasher<AppUser>();

            // seeding roles

            var AdminRole = new AppRole()
            {
                Id = adminRoleId,
                Name = "Admin",
                RoleDescription = "Superusuario"
            };

            AdminRole.NormalizedName = AdminRole.Name.ToUpper();

            var MemberRole = new AppRole()
            {
                Id = memberRoleId,
                Name = "Miembro",
                RoleDescription = "Usuario con acceso restringido"
            };

            MemberRole.NormalizedName = MemberRole.Name.ToUpper();

            List<AppRole> Roles = new List<AppRole>()
            {
                AdminRole,
                MemberRole
            };

            builder.Entity<AppRole>().HasData(Roles);
            // seeding users
            var AdminUser = new AppUser
            {
                Id = adminUserId,
                UserName = "admin@correo.com",
                Email = "admin@correo.com",
                EmailConfirmed = false,
                FirstName = "Admin",
                LastName = "Del Sistem",
                PhoneNumber = "1234567890",
                Address = "Managua, Managua"
            };

            AdminUser.NormalizedUserName = AdminUser.UserName.ToUpper();
            AdminUser.NormalizedEmail = AdminUser.Email.ToUpper();
            AdminUser.PasswordHash = HashPwd.HashPassword(null, Password);

            var MemberUser = new AppUser
            {
                Id = memberUserId,
                UserName = "miembro@correo.com",
                Email = "miembro@correo.com",
                EmailConfirmed = false,
                FirstName = "Miembro",
                LastName = "Del Sistem",
                PhoneNumber = "1234567890",
                Address = "Managua, Managua"
            };

            MemberUser.NormalizedUserName= MemberUser.UserName.ToUpper();
            MemberUser.NormalizedEmail= MemberUser.Email.ToUpper();
            MemberUser.PasswordHash = HashPwd.HashPassword(null, Password);

            List<AppUser> users = new List<AppUser>()
            {
                AdminUser,
                MemberUser
            };

            builder.Entity<AppUser>().HasData(users);

            // seeding user-role
            List<IdentityUserRole<string>> UserRoles = new List<IdentityUserRole<string>>();

            UserRoles.Add(new IdentityUserRole<string>
            {
                UserId = adminUserId,
                RoleId = adminRoleId
            });

            UserRoles.Add(new IdentityUserRole<string>
            {
                UserId = memberUserId,
                RoleId = memberRoleId
            });

            builder.Entity<IdentityUserRole<string>>().HasData(UserRoles);
        }
    }
}
