using System.Text.Json.Serialization;

namespace MusicAppAPI.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string SongName { get; set; } = string.Empty;
        public string ArtistName { get; set; } = string.Empty;
        public string SongUrl { get; set; } = string.Empty;

        public int SongRating { get; set; } = 1; 
        public bool IsFavorite { get; set; }

        public DateTime? SongEntered { get; set; } = DateTime.Now;
        public DateTime? SongEdited { get; set; } = DateTime.Now;

        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }

        /*
        public Category? Category { get; set; }
        public int CategoryId { get; set; }*/
    }
}
