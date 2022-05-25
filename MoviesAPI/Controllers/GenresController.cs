using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesAPI.DTO;
using MoviesAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenresController: ControllerBase
    {
        private readonly ILogger<GenresController> _logger;
        private readonly ApplicationDbContext _context;


        public GenresController(ILogger<GenresController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet] // api/genres
        public async Task<ActionResult<List<Genre>>> Get()
        {
            var genres = await _context.Genres.Include(x=> x.Movies).ToListAsync();
            return genres;
        }

        [HttpGet("{Id:int}")] 
        public async Task<ActionResult<Genre>> Get(int Id)
        {
            var genre = await _context.Genres.Include(x=>x.Movies).FirstOrDefaultAsync(x => x.Id == Id);

            if (genre == null)
            {
                return NotFound();
            }
            return genre;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateGenreDto genreDto)
        {
            Genre genre = new Genre();
            genre.Name = genreDto.Name;

            _context.Add(genre);
            await _context.SaveChangesAsync();

            return Ok(genre);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Genre genre)
        {
            var genreDb = await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);

            if (genreDb == null)
            {
                return NotFound();
            }

            genreDb.Name = genre.Name;

            _context.Update(genreDb);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await _context.Genres.AnyAsync(x => x.Id == id);
            if (!exists)
            {
                return NotFound();
            }

            _context.Remove(new Genre() { Id = id });
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
