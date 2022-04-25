using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AdminService : IAdminService
    {
        private readonly IMovieRepository _movieRepository;

        public AdminService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
            
        }
        public async Task<bool> AddMovie(MovieAdminModel movie)
        {

            //how to check whether movie exists. model doesn't contain id
            var movies = await _movieRepository.GetMoviebyTitle(movie.Title);
            if (movies != null)
            {
                // 
                throw new Exception("Duplicate movie, please use Update function");
            }

            var newMovie = new Movie
            {
                Title = movie.Title,
                PosterUrl = movie.PosterUrl,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                ReleaseDate = movie.ReleaseDate,
                Overview = movie.Overview,
                TmdbUrl = movie.TmdbUrl,
                Tagline = movie.Tagline,
                BackdropUrl = movie.BackdropUrl,
                OriginalLanguage = movie.OriginalLanguage,
                RunTime = movie.RunTime,
                Price = movie.Price,

            };

            await _movieRepository.Add(newMovie);

            return true;
        }

        public async Task<bool> UpdateMovie(MovieAdminModel movie)
        {

            //how to check whether movie exists. model doesn't contain id
            var movies = await _movieRepository.GetMoviebyTitle(movie.Title);
            if (movies == null)
            {
                // 
                throw new Exception("No movie found, please use Add function");
            }

            var updatedMovie = new Movie
            {
                Title = movie.Title,
                PosterUrl = movie.PosterUrl,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                ReleaseDate = movie.ReleaseDate,
                Overview = movie.Overview,
                TmdbUrl = movie.TmdbUrl,
                Tagline = movie.Tagline,
                BackdropUrl = movie.BackdropUrl,
                OriginalLanguage = movie.OriginalLanguage,
                RunTime = movie.RunTime,
                Price = movie.Price,

            };

            await _movieRepository.Update(updatedMovie);

            return true;
        }


    }
}
