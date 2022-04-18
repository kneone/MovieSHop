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
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public Task<Review> GetReviewById(int userId, int movieId)
        {
            var review = _dbContext.Reviews.Include(m => m.Users).Include(m => m.Movie)
                  .FirstOrDefaultAsync(m => m.UserId == userId && m.MovieId == movieId);


            return review;
        }
    }
}
