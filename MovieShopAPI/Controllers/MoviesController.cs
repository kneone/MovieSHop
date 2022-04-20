using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    // attribute Routing
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("top-grossing")]
        // http://localhost/api/movies/top-grossing
        public async Task<IActionResult> GetTopReveuneMovies()
        {
            // callmovie service to get the data
            var movies = await _movieService.Get30HighestGrossingMovies();
            if (!movies.Any())
            {
                return NotFound(new { errorNessage = "No Movies Found" });
            }
            // ASP.NET Core Converts, serializes C# object to JSON objects automatically
            // Syste.TextJson.Librart

            // .net vversion 2 or less
            // .NET Framework(old) => NewtonSofe.Json
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id:int}")]
        // http://localhost/api/movies/4
        public async Task<IActionResult> GetMovieDetails(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);
            if(movie == null)
                return NotFound(new { errorNessage = "No Movie Found for id" });
            return Ok(movie);
        }
    }
}
