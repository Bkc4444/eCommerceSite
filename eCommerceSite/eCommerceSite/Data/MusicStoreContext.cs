using eCommerceSite.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceSite.Data
{
    public class MusicStoreContext : DbContext
    {
        /// <summary>
        /// This builds a constructor for the database
        /// </summary>
        /// <param name="options"></param>
        public MusicStoreContext(DbContextOptions<MusicStoreContext> options) : base(options)
        {
        }

        public DbSet<Music> Musics { get; set; }


    }
}
