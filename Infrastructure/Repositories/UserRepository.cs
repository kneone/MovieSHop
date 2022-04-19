using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserByEmail(string email)
        {
            //var user = await _dbContext.Users.Include(m=>m.PurchasesOfUser).Include(m=>m.ReviewsOfUser).Include(m=>m.FavoritesOfUser).FirstOrDefaultAsync(x => x.Email == email);
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }
        public override async Task<User> GetById(int id)
        {
            var user = await _dbContext.Users.Include(m => m.PurchasesOfUser).Include(m => m.ReviewsOfUser).Include(m => m.FavoritesOfUser).FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }
    }
}