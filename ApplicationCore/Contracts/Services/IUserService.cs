using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IUserService
    {
        Task PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId);
        Task <bool>IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId);
        
        Task <PurchaseRequestModel> GetAllPurchasesForUser(int id);

        Task<PurchaseDetailsModel> GetPurchasesDetails(int userId, int movieId);
        Task AddFavorite(FavoriteRequestModel favoriteRequest);
        Task RemoveFavorite(FavoriteRequestModel favoriteRequest);
        Task FavoriteExists(int id, int movieId);
        Task <List<MovieCard>>GetAllFavoritesForUser(int id);
        Task AddMovieReview(ReviewRequestModel reviewRequest);
        Task UpdateMovieReview(ReviewRequestModel reviewRequest);
        Task DeleteMovieReview(int userId, int movieId);
        Task<List<MovieCard>> GetAllReviewsByUser(int id);
        
    }
}
