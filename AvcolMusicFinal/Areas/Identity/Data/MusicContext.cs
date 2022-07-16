using AvcolMusicFinal.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AvcolMusicFinal.Models;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AvcolMusicFinal.Areas.Identity.Data
{

    public class MusicContext : IdentityDbContext<ACUser>
    {
        public MusicContext(DbContextOptions<MusicContext> options)
            : base(options)
        {

        }
        public DbSet<AvcolMusicFinal.Models.Group> Group { get; set; }

        public DbSet<AvcolMusicFinal.Models.Lesson> Lesson { get; set; }

        public DbSet<AvcolMusicFinal.Models.Teacher> Teacher { get; set; }

        public DbSet<AvcolMusicFinal.Models.Class> Class { get; set; }

        public DbSet<AvcolMusicFinal.Models.MusicTimetable> MusicTimetable { get; set; }

        public DbSet<AvcolMusicFinal.Models.Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }

    public class MusicContextFactory : IDesignTimeDbContextFactory<MusicContext>
    {
        public MusicContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MusicContext>();
            optionsBuilder.UseSqlServer("DefaultConnection");

            return new MusicContext(optionsBuilder.Options);
        }
    }
}
