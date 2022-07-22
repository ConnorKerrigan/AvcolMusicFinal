using Microsoft.Extensions.DependencyInjection;
using System;
using AvcolMusicFinal.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AvcolMusicFinal.Models
{
    public class Seeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<MusicContext>();

            string[] roles = new string[] { "Admin", "Teacher", "Student" };

            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);

                if (!context.Roles.Any(r => r.Name == role))
                {
                    roleStore.CreateAsync(new IdentityRole(role));
                }
            }
            context.SaveChangesAsync();
        }
    }
}
