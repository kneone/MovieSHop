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

        public UserService(IUserRepository userRepository, IPurchaseRepository purchaseRepository)
        {
            _userRepository = userRepository;
            _purchaseRepository = purchaseRepository;
        }

        public async Task AddFavorite(FavoriteRequestModel favoriteRequest)
        {
            throw new NotImplementedException();
        }

        public Task AddMovieReview(ReviewRequestModel reviewRequest)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovieReview(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        public Task FavoriteExists(int id, int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<List<MovieCard>> GetAllFavoritesForUser(int id)
        {
            throw new NotImplementedException();
        }      

        //public async Task<PurchaseRequestModel> GetAllPurchasesForUser(int id)
        //{
        //    var user = await _userRepository.GetById(id);
        //    var purchaseMovie = await _purchaseRepository.GetById(id);
        //    return new PurchaseRequestModel;
        //}

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

        public Task RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMovieReview(ReviewRequestModel reviewRequest)
        {
            throw new NotImplementedException();
        }

        Task<PurchaseRequestModel> IUserService.GetAllPurchasesForUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
