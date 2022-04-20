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
    public class FavoriteRepository : Repository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public Task<Favorite> GetFavoriteById(int userId, int movieId)
        {
            var favorite = _dbContext.Favorites.Include(m => m.Users).Include(m => m.Movie)
                   .FirstOrDefaultAsync(m => m.UserId == userId && m.MovieId == movieId);
            // use review dbset (table) to get average rating of the movie and assign it to movie.Rating

            return favorite;
        }

        public async Task<List<Favorite>> GetFavoriteForUser(int id)
        {
            var favorites = await _dbContext.Favorites.Include(m => m.Movie).Where(f => f.UserId == id).ToListAsync();
            return favorites;
        }
    }
}
