using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Route("purchases")]
        public async Task<IActionResult> Purchase(int id)
        {
            // mechanism to handle exception globally
            // Exception filters

            

            var purchase = await _userService.GetAllPurchasesForUser(id);
            if(purchase == null)
            {
                return NotFound(new { errorNessage = "No Purchase Found for User" });
            }
            // get the list of movies for user
            // get the userid. httpcontext

            return Ok(purchase);
        }

        [HttpGet]
        [Route("favorites")]
        public async Task<IActionResult> Favorite(int id)
        {
            // mechanism to handle exception globally
            // Exception filters



            var favorite = await _userService.GetAllFavoritesForUser(id);
            if (favorite == null)
            {
                return NotFound(new { errorNessage = "No Favorites Found for User" });
            }
            // get the list of movies for user
            // get the userid. httpcontext

            return Ok(favorite);
        }

        
        [HttpGet]
        [Route("movie-reviews")]
        public async Task<IActionResult> Reviews(int id)
        {
            // mechanism to handle exception globally
            // Exception filters



            var review = await _userService.GetAllReviewsByUser(id);
            if (review == null)
            {
                return NotFound(new { errorNessage = "No Reviews Found for User" });
            }
            // get the list of movies for user
            // get the userid. httpcontext

            return Ok(review);
        }
    }
}
