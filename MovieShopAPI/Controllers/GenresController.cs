using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetGenreDetails(int id)
        {
            var genre = await _genreService.GetMovieForGenre(id);
            if (genre == null)
                return NotFound(new { errorNessage = "No Genre Found for id" });
            return Ok(genre);
        }
    }
}
