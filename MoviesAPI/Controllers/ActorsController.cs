using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesAPI.DTO;
using MoviesAPI.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorsController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ActorsController> _logger;

        public ActorsController(ApplicationDbContext context, ILogger<ActorsController> logger)
        {
            _context = context;
            _logger = logger;
         
        }

        [HttpGet]
        public async Task<ActionResult<List<Actor>>> Get()
        {
            _logger.LogInformation("Get method called");
            return _context.Actors.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> Get(int id)
        {
            var person = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);

            if (person == null)
            {
                return NotFound();
            }
            return person;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CreateActorDto actorDto)
        {
            Actor actor = new Actor();
            actor.Biography = actorDto.Biography;
            actor.DateOfBirth = actorDto.DateOfBirth;
            actor.Name = actorDto.Name;
            _context.Add(actor);
            await _context.SaveChangesAsync();
            return Ok(actor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] Actor actor)
        {
            var personDB = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            if (personDB == null) { return NotFound(); }

            personDB.Biography = actor.Biography;
            personDB.DateOfBirth = actor.DateOfBirth;
            personDB.Name = actor.Name;

            _context.Update(personDB);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await _context.Actors.AnyAsync(x => x.Id == id);
            if (!exists)
            {
                return NotFound();
            }

            _context.Remove(new Actor() { Id = id });
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
