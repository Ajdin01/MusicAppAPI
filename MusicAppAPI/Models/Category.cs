namespace MusicAppAPI.Models
{
    public class Category
    {
        public int Id { get; set; }

        public enum SongCategory
        {
            Rock,
            Pop,
            HipHop,
            Indie,
            Alternative,
            Jazz
        }
    }
}
