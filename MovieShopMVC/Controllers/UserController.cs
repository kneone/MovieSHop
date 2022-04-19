using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // show all the movies purchase by currently loged in user
        [HttpGet]
        
        public async Task<IActionResult> Purchase()
        {
            // first whether user is loged in
            // if the user is not loged in
            // redirect to login page,

            // 10:00Am user email/password => something that can be used at 10:05
            // cookies, authentication cookies that can be used across http request and check whether
            //user is loged in or not
            // cookies -> location? -> browser

            // 10:05 he/she calls user/purchases
            // look for the auth cookies and look for exp time and get the userid

            // userid, go to purchase table and get all the movies purchased
            // display as movie cards, use movie card partial view

            //var data = this.HttpContext.Response.Cookies["MovieShopAuthCookie"];

            //var isLogedIn = this.HttpContext.User.Identities.IsAuthenticated;
            //if(!isLogedIn)
            //{
            //    // redirect to the login page
            //}
            //var userId = this.HttpContext.User.Claims.FirstOrDefault(x => x.ValueType == ClaimType.Identifiers)?.Value;

            // Filters in ASP.NET
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var purchases = await _userService.GetAllPurchasesForUser(userId);


            // call the UserService -> GetMoviesPurchasedByUser(int userId) -> List<MovieCard>

            return View(purchases);
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var favorties = await _userService.GetAllFavoritesForUser(userId);
            return View();
        }

        public async Task<IActionResult> Reviews()
        {
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var reviews = await _userService.GetAllReviewsByUser(userId);
            
            return View();
        }
    }
}
