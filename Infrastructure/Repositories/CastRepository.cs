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
    public class CastRepository : Repository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public override Task<Cast> GetById(int id)
        {
            // Include method to include the navigation properties
            // Add Cast and MovieCast to the includes to get cast information
            var cast = _dbContext.Casts.Include(m => m.MovieOfCast).ThenInclude(m => m.Movie)
                    .FirstOrDefaultAsync(m => m.Id == id);
            // use review dbset (table) to get average rating of the movie and assign it to movie.Rating

            return cast;
        }
    }
}
