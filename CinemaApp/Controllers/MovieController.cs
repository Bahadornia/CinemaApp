using CinemaApp.Data;
using CinemaApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private CinemaAppDbContext _dbContext;

        public MovieController(CinemaAppDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        // GET: api/<MovieController>
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return _dbContext.Movies;
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public Movie Get(int id)
        {

            var movie = _dbContext.Movies.Find(id);
            return movie;
        }

        // POST api/<MovieController>
        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();   
            return StatusCode(StatusCodes.Status200OK);
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie movie)
        {

            var foundedMovie = _dbContext.Movies.Find(id);
            foundedMovie.Name = movie.Name;
            foundedMovie.Language = movie.Language;
            _dbContext.SaveChanges();
            return Ok("Updated Successfuly");

        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var movie = _dbContext.Movies.Find(id);
            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
            return Ok("Deleted Successfully.");
        }
    }
}
