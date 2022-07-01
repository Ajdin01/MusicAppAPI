namespace MusicAppAPI
{
    public class EditSongDTO
    {
        //data transfer object for editing songs

        public int Id { get; set; }
        public string SongName { get; set; } = string.Empty;
        public string ArtistName { get; set; } = string.Empty;
        public string SongUrl { get; set; } = string.Empty;

        public int SongRating { get; set; } = 1;
        public bool IsFavorite { get; set; }

        public DateTime? SongEdited { get; set; } = DateTime.Now;
    }
}
