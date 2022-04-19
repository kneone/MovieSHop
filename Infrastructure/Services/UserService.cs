using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IReviewRepository _reviewRepository;

        public UserService(IUserRepository userRepository, IPurchaseRepository purchaseRepository, IFavoriteRepository favoriteRepository, IReviewRepository reviewRepository)

        {
            _userRepository = userRepository;
            _purchaseRepository = purchaseRepository;
            _favoriteRepository = favoriteRepository;
            _reviewRepository = reviewRepository;
        }

        public async Task AddFavorite(FavoriteRequestModel favoriteRequest)
        {
            var user = await _userRepository.GetById(favoriteRequest.UserId);
            if (!(await FavoriteExists(favoriteRequest.UserId, favoriteRequest.MovieId)))
            {
                var favorite = new Favorite
                {
                    MovieId = favoriteRequest.MovieId,
                    UserId = favoriteRequest.UserId
                };
                await _favoriteRepository.Add(favorite);
            }
        }

        public async Task AddMovieReview(ReviewRequestModel reviewRequest)
        {
            var user = await _userRepository.GetById(reviewRequest.UserId);
            
            bool isReview = false;
            foreach (var review in user.ReviewsOfUser)
            {
                if (review.MovieId == reviewRequest.MovieId)
                {
                    var newreview = new Review
                    {

                        MovieId = reviewRequest.MovieId,
                        UserId = reviewRequest.UserId,
                        Rating = reviewRequest.Rating,
                        ReviewText = reviewRequest.ReviewText

                    };
                    await _reviewRepository.Add(newreview);
                }
                else 
                {
                    throw new Exception("Review Already exsisted");
                }
            }
        }

        public Task DeleteMovieReview(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        public async Task <bool> FavoriteExists(int id, int movieId)
        {
            var user = await _userRepository.GetById(id);
            bool isFavorite = false;
            foreach (var Favorite in user.FavoritesOfUser)
            {
                if (Favorite.MovieId == movieId)
                {
                    isFavorite = true; ;
                }
                
                
            }
            return isFavorite;    
        }

        public async Task<List<Favorite>> GetAllFavoritesForUser(int id)
        {
            var user = await _userRepository.GetById(id);
            var userFirstname = user.FirstName;
            var userLastname = user.LastName;
            var user2 = user.DateOfBirth;
            var user3 = user.Email;
            
            var favorite = new List<Favorite>();
            foreach (var favorites in user.FavoritesOfUser)
            {
                favorite.Add(new Favorite
                {
                    Id = favorites.Id,
                    UserId = favorites.UserId,
                    MovieId = favorites.MovieId
                });
            }
            return favorite;
        }

        public async Task<PurchaseResponseModel> GetAllPurchasesForUser(int id)
        {
            var user = await _userRepository.GetById(id);
           var userFirstname = user.FirstName;
            var purchase = new List<MovieCard>();
            var test = user.PurchasesOfUser;
            foreach (var purchases in user.PurchasesOfUser)
            {
                //var newpurchases = _purchaseRepository.GetPurchaseById(id);
                purchase.Add(new MovieCard
                {
                    Id = purchases.Id,
                    //Title = purchases.Movie.Title,
                    //PosterUrl = purchases.Movie.Title
                });              
                //purchase.Add(new PurchaseDetailsModel { Id = purchases.Id, UserId = purchases.UserId, PurchaseNumber = purchases.PurchaseNumber, TotalPrice = purchases.TotalPrice,
                //PurchaseDateTime = purchases.PurchaseDateTime, MovieId = purchases.MovieId});
            }

            var purchaseOfUser = new PurchaseResponseModel
            {
                UserId = id,
                NumberOfMoviesPurchased = purchase.Count,
                PurchaseOfMovieCards = purchase

            };
            return purchaseOfUser;
        }

        public Task<List<MovieCard>> GetAllReviewsByUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PurchaseDetailsModel> GetPurchasesDetails(int userId, int movieId)
        {
            var purchases = await _purchaseRepository.GetPurchaseById(userId, movieId);
            var purchasesDetails = new PurchaseDetailsModel
            {
                Id = purchases.Id,
                UserId = userId,
                PurchaseNumber = purchases.PurchaseNumber,
                TotalPrice = purchases.TotalPrice,
                PurchaseDateTime = purchases.PurchaseDateTime,
                MovieId = movieId
            };
            return purchasesDetails;
                
                
            
        }

        public async Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId)
        {
            var purchase = await _purchaseRepository.GetPurchaseById(userId, purchaseRequest.MovieId);
            if (purchase == null)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public async Task PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId)
        {
            var purchase = await _purchaseRepository.GetPurchaseById(userId, purchaseRequest.MovieId);
            if(purchase == null)
            {
                var newpurchase = new Purchase
                {
                    Id = purchaseRequest.Id,
                    UserId=userId,
                    PurchaseNumber = purchaseRequest.PurchaseNumber,
                    TotalPrice = purchaseRequest.TotalPrice,
                    PurchaseDateTime= purchaseRequest.PurchaseDateTime,
                    MovieId = purchaseRequest.MovieId
                };

                await _purchaseRepository.Add(newpurchase);
            }
            
        }

        public async Task RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            if ((await FavoriteExists(favoriteRequest.UserId, favoriteRequest.MovieId)))
            {
                var favorite = await _favoriteRepository.GetFavoriteById(favoriteRequest.UserId, favoriteRequest.MovieId);
                await _favoriteRepository.Delete(favorite);

            }
            else 
            {
                throw new Exception("No favorite");
            }

        }

        public Task UpdateMovieReview(ReviewRequestModel reviewRequest)
        {
            throw new NotImplementedException();
        }

       
    }
}
