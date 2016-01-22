namespace LINQdIn.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Regular" });
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "Employer" });
            }

            var adminUser = userManager.Users.FirstOrDefault(x => x.Email == "admin@gmail.com");

            if (adminUser == null)
            {
                var admin = new User
                {
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Admin",
                    LastName = "Admin",
                    RegisteredOn = DateTime.Now.AddYears(-1),
                };

                userManager.Create(admin, "123456qwerty");
            }

            adminUser = userManager.Users.FirstOrDefault(x => x.Email == "admin@gmail.com");

            if (adminUser != null)
            {
                userManager.AddToRoles(adminUser.Id, "Regular", "Admin", "Employer");
            }
        }
    }
}
