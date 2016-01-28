namespace LINQdIn.Data.Migrations
{
    using System;
    using System.Collections.Generic;
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
                    ProfilePhotoUrl = "~/UploadedFiles/ProfileImages/avatar-placeholder.jpg",
                    RegisteredOn = DateTime.Now.AddYears(-1),
                };

                userManager.Create(admin, "123456qwerty");
                userManager.AddToRole(admin.Id, "Regular");
            }

            if (userManager.Users.FirstOrDefault(x => x.Email == "niki@kostov.com") == null)
            {
                var user = new User
                {
                    Email="niki@kostov.com",
                    UserName = "niki@kostov.com",
                    FirstName = "Nikolay",
                    LastName = "Kostov",
                    ProfilePhotoUrl = "~/UploadedFiles/ProfileImages/avatar-placeholder.jpg",
                    RegisteredOn = DateTime.Now
                };

                userManager.Create(user, "123456");
                userManager.AddToRole(user.Id, "Regular");
            }

            if (userManager.Users.FirstOrDefault(x => x.Email == "ivaylo@kenov.com") == null)
            {
                var user = new User
                {
                    Email = "ivaylo@kenov.com",
                    UserName = "ivaylo@kenov.com",
                    FirstName = "Ivaylo",
                    LastName = "Kenov",
                    ProfilePhotoUrl = "~/UploadedFiles/ProfileImages/avatar-placeholder.jpg",
                    RegisteredOn = DateTime.Now
                };

                userManager.Create(user, "123456");
                userManager.AddToRole(user.Id, "Regular");
            }

            if (userManager.Users.FirstOrDefault(x => x.Email == "kon@simeonov.com") == null)
            {
                var user = new User
                {
                    Email = "kon@simeonov.com",
                    UserName = "kon@simeonov.com",
                    FirstName = "Konstantin",
                    LastName = "Simeonov",
                    ProfilePhotoUrl = "~/UploadedFiles/ProfileImages/avatar-placeholder.jpg",
                    RegisteredOn = DateTime.Now
                };

                userManager.Create(user, "123456");
                userManager.AddToRoles(user.Id, "Regular", "Admin");
            }

            if (userManager.Users.FirstOrDefault(x => x.Email == "nicky94@gmail.com") == null)
            {
                var user = new User
                {
                    Email = "nicky94@gmail.com",
                    UserName = "nicky94@gmail.com",
                    FirstName = "Niki",
                    LastName = "Novkirishki",
                    ProfilePhotoUrl = "~/UploadedFiles/ProfileImages/avatar-placeholder.jpg",
                    RegisteredOn = DateTime.Now
                };

                userManager.Create(user, "123456");
                userManager.AddToRole(user.Id, "Regular");
            }

            adminUser = userManager.Users.FirstOrDefault(x => x.Email == "admin@gmail.com");

            if (adminUser != null)
            {
                userManager.AddToRoles(adminUser.Id, "Regular", "Admin", "Employer");
            }

            if(!context.Skills.Any())
            {
                var seedSkills = new List<string>()
                {
                    "C#",
                    ".NET",
                    "LINQ",
                    "Underscore.js",
                    "ASP DO(N)T NET",
                    "OOP",
                    "OOD",
                    "NoSQL databases",
                    "Design Patterns",
                    "Entity Framework",
                    "MVC",
                    "Git",
                    "TDD",
                    "BDD",
                    "SPA Applicaitons",
                    "Management",
                    "MEAN Stack",
                    "Angular",
                    "NodeJS",
                    "Python",
                    "Ruby",
                    "Ruby on rails",
                    "jQuery",
                    "Javascript",
                    "Trumpscript",
                    "Handlebars",
                    "View engines",
                    "Game engines",
                    "SQL",
                    "MS SQL Server",
                    "QA",
                    "Web Api",
                    "RESTful Services",
                    "Brainfuck"
                };

                foreach (var skillName in seedSkills)
                {
                    context.Skills.Add(new Skill() { Name = skillName });
                }

                context.SaveChanges();

                context.Skills.Take(5).ToList().ForEach(x => adminUser.Skills.Add(x));

                var allUsers = context.Users.AsQueryable();
                var rng = new Random();

                foreach (var user in allUsers)
                {
                    if (user.Skills.Count() < 2)
                    {
                        var count = rng.Next(3, 17);
                        context.Skills.OrderBy(x => Guid.NewGuid()).Take(count).ToList().ForEach(s => user.Skills.Add(s)); 
                        context.Users.AddOrUpdate(user);
                    }
                }
                
                context.SaveChanges();
            }
        }
    }
}
