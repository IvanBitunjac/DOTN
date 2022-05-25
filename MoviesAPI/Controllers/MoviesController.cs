
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.Extensions.Logging;
using MoviesAPI.DTO;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(ApplicationDbContext context,
            ILogger<MoviesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> Get()
        {
            return _context.Movies.ToList();          
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> Get(int id)
        {
            var movie = await _context.Movies
                .Include(x => x.Genre)
                .Include(x => x.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CreateMovieDto movie)
        {
            Movie newMovie = new Movie();
            newMovie.Title = movie.Title;
            newMovie.Summary = movie.Summary;
            newMovie.ActorId = movie.ActorId;
            newMovie.GenreId = movie.GenreId;
            _context.Add(newMovie);

            await _context.SaveChangesAsync();
            return Ok(newMovie);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] Movie movie)
        {
            var movieDB = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);

            if (movieDB == null)
            {
                return NotFound();
            }

            movieDB.Title = movie.Title;
            movieDB.Summary = movie.Summary;
            movieDB.ActorId = movie.ActorId;
            movieDB.GenreId = movie.GenreId;

            _context.Update(movieDB);
            await _context.SaveChangesAsync();
            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await _context.Movies.AnyAsync(x => x.Id == id);

            if (!exists)
            {
                return NotFound();
            }

            _context.Remove(new Movie() { Id = id });
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
