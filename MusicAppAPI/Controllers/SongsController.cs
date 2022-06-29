using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAppAPI.Models;

namespace MusicAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly DataContext _context;
        public SongsController(DataContext context)
        {
            _context = context;
        }

        /*
        The real method - cus the library is supposed to show only the users songs

        [HttpGet]
        public async Task<ActionResult<List<Song>>> GetAllUsersSongs(int id)
        {
            var user = await _context.Users.FindAsync(id);

            var songs = await _context.Songs.Where(s => s.UserId == user.Id).ToListAsync();
            return Ok(songs);
        }
        */

        //This gets all the songs from the db
        [HttpGet]
        public async Task<ActionResult<List<Song>>> GetAllUsersSongs()
        {

            var songs = await _context.Songs.ToListAsync();
            return Ok(songs);
        }


        [HttpPost]

        public async Task<ActionResult<List<Song>>> AddSong(CreateSongDTO request, int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if(user == null)
            {
                return NotFound("") ;
            }

            var newSong = new Song 
            {
                SongName = request.SongName,
                ArtistName = request.ArtistName,
                SongRating = request.SongRating,
                IsFavorite = request.IsFavorite,
                SongEntered = DateTime.Now,
                SongUrl = request.SongUrl,
            };

            newSong.UserId = userId;

            _context.Songs.Add(newSong);
            await _context.SaveChangesAsync();

            return await GetAllUsersSongs(newSong.UserId);

        }

        [HttpPut]

        public async Task<ActionResult<List<Song>>> UpdateSong(Song song)
        {
            var existingSong = await _context.Songs.FindAsync(song.Id);
            if (existingSong == null)
                return BadRequest("Song not found.");

            existingSong.SongName = song.SongName;
            existingSong.ArtistName = song.ArtistName;
            existingSong.SongRating = song.SongRating;
            existingSong.IsFavorite = song.IsFavorite;
            existingSong.SongEdited = DateTime.Now;
            
            await _context.SaveChangesAsync();

            return Ok(await _context.Songs.ToListAsync());
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Song>>> DeleteSong(int id)
        {
            var existingHero = await _context.Songs.FindAsync(id);
            if (existingHero == null)
                return BadRequest("Song doesn't exist.");

            _context.Songs.Remove(existingHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Songs.ToListAsync());
        }

        
    }
}
