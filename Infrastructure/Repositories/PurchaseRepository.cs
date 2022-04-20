using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public Task<Purchase> GetPurchaseById(int id, int movieId)
        {
            // Include method to include the navigation properties
            // Add Cast and MovieCast to the includes to get cast information
            var purchase = _dbContext.Purchases.Include(m => m.Users).Include(m => m.Movie).ThenInclude(m=>m.Title).Include(m=>m.Movie).ThenInclude(m=>m.PosterUrl)
                    .FirstOrDefaultAsync(m => m.Id == id &&  m.MovieId == movieId);
            // use review dbset (table) to get average rating of the movie and assign it to movie.Rating

            return purchase;
        }

        public async Task<List<Purchase>> GetPurchasesForUser(int id)
        {
           var purchases = await _dbContext.Purchases.Include(m=> m.Movie).Where(p=> p.UserId ==id).ToListAsync();
            return purchases;
        }
    }
}
