using Microsoft.EntityFrameworkCore;
using MusicAppAPI.Models;
using System.Text;

namespace MusicAppAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "TestUser", PasswordHash = Encoding.ASCII.GetBytes("DlZMTV1i8THYc/8TwWc7YlLL8d0XCmLP0RyXJBxm+EUfoGdIcuF398Ax0pXLh8ZUsACeTbZk4+UDPGtuZEVakg=="), PasswordSalt = Encoding.ASCII.GetBytes("/zBrueeXdmCM2NVBabpGqqxx/XE08rkt4+jPT1Mk4On+JzS3+LGoNMSc1jgaB4cWSdmxeG9bdCvKwhJbaureU+xBPxKhZbC91ykE7sPpHUmwfFN/XTDSF0RBly0wd2tMBoC8i6UoZLen9MAbosLF1UHMIa1pPEzpYoifsU9MOTs=") },
                new User { Id = 2, Username = "Ajdin", PasswordHash = Encoding.ASCII.GetBytes("DlZMTV1i8THYc/8TwWc7YlLL8d0XCmLP0RyXJBxm+EUfoGdIcuF398Ax0pXLh8ZUsACeTbZk4+UDPGtuZEVakg=="), PasswordSalt = Encoding.ASCII.GetBytes("/zBrueeXdmCM2NVBabpGqqxx/XE08rkt4+jPT1Mk4On+JzS3+LGoNMSc1jgaB4cWSdmxeG9bdCvKwhJbaureU+xBPxKhZbC91ykE7sPpHUmwfFN/XTDSF0RBly0wd2tMBoC8i6UoZLen9MAbosLF1UHMIa1pPEzpYoifsU9MOTs=") }

                );

            modelBuilder.Entity<Song>().HasData(
                new Song { Id = 1, SongName = "TestSong", ArtistName = "TestArtist", IsFavorite = true, SongRating = 4, SongEntered = DateTime.Now, SongEdited = DateTime.Now, SongUrl = "testURL", UserId = 1 },
                new Song { Id = 2, SongName = "TestSong2", ArtistName = "TestArtist2", IsFavorite = false, SongRating = 2, SongEntered = DateTime.Now, SongEdited = DateTime.Now, SongUrl = "testURL2", UserId = 1 },
                new Song { Id = 3, SongName = "TestSong3", ArtistName = "TestArtist3", IsFavorite = true, SongRating = 5, SongEntered = DateTime.Now, SongEdited = DateTime.Now, SongUrl = "testURL3", UserId = 2 }

                );
        }

        //database sets below


        public DbSet<User> Users => Set<User>();
        public DbSet<Song> Songs { get; set; }

        //categories not in yet
        //public DbSet<Category> Categories { get; set; }
    }
}
