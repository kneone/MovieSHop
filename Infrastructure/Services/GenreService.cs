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
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<GenreModel> GetMovieForGenre(int id)
        {
            var genre = await _genreRepository.GetGenreById(id);
            var genrecard = new List<MovieCard>();
            foreach (var movie in genre.MoviesOfGenre)
            {
                genrecard.Add(new MovieCard
                {
                    Id = movie.MovieId,
                    Title = movie.Movie.Title,
                    PosterUrl = movie.Movie.PosterUrl
                });
            }

            var genreDetails = new GenreModel
            {

                Id = genre.Id,
                Name = genre.Name,
                GenreOfMovieCards = genrecard

            };
            //may need to return castDetailModel
            return genreDetails;
        }
    }
}
