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
        private readonly IGenreService _genreService;
        public MoviesController(IMovieService movieService, IGenreService genreService)
        {
            _movieService = movieService;
            _genreService = genreService;


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
        [Route("top-rated")]
        public async Task<IActionResult> GetTopRatedMovies()
        {
            var movies = await _movieService.Get30HighestRatedMovies();
            if (!movies.Any())
            {
                return NotFound(new { errorNessage = "No Movies Found" });
            }

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

        [HttpGet]
        [Route("{id:int}/reviews")]
        public async Task<IActionResult> GetMovieReviews(int id)
        {
            var review = await _movieService.GetReviewByMovieId(id);
            if (review == null)
                return NotFound(new { errorNessage = "No Review Found for id" });
            return Ok(review);
        }


        
        [HttpGet]
        [Route("genre")]
        public async Task<IActionResult> GetGenreDetails(int id)
        {
            var genre = await _genreService.GetMovieForGenre(id);
            if (genre == null)
                return NotFound(new { errorNessage = "No Genre Found for id" });
            return Ok(genre);
        }
        
    }
}
