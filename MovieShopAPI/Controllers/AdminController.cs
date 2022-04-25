using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IAdminService _adminService;
        public AdminController(IMovieService movieService, IAdminService adminService)
        {
            _movieService = movieService;
            _adminService = adminService;
        }

        [HttpPost]
        [Route("movie")]
        public async Task<IActionResult> addMovie(MovieAdminModel movie)
        {
            var newMovie = await _adminService.AddMovie(movie);
            return Ok(newMovie);
        }

        [HttpPut]
        [Route("movie")]
        public async Task<IActionResult> updateMovie(MovieAdminModel movie)
        {
            var updatedMovie = await _adminService.UpdateMovie(movie);
            return Ok(updatedMovie);
        }
    }
}
