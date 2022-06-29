using MusicAppAPI.Models;
using System.Text.Json.Serialization;

namespace MusicAppAPI
{
    public class CreateSongDTO
    {
        public string SongName { get; set; } = string.Empty;
        public string ArtistName { get; set; } = string.Empty;
        public string SongUrl { get; set; } = string.Empty;

        public int SongRating { get; set; } = 1;
        public bool IsFavorite { get; set; }

        public DateTime? SongEntered { get; set; } = DateTime.Now;
    }
}
