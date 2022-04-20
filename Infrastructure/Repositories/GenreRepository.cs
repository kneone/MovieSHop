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
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Genre>> GetGenreForMovie(int id)
        {
            var genres = await _dbContext.Genres.Include(m => m.MoviesOfGenre).ThenInclude(m => m.Movie).Where(m => m.Id == id).ToListAsync();
            //var genres = await _dbContext.Genres.Include(m => m.Movie).Where(f => f.UserId == id).ToListAsync();
            return genres;
        }
    }
}
