﻿using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // DI IMovieRepository
        // Models are nothing but dumb classes that transfer data, ViewModels, Models, DTO (Data Transfer Objects)
        public List<MovieCard> Get30HighestGrossingMovies()
        {
            var movies = _movieRepository.Get30HighestGrossingMovies();
            // AutoMapper - Nuget
            var movieCards = new List<MovieCard>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCard { Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title });
            }
            return movieCards;
        }

        public MovieDetailsModel GetMovieDetails(int id)
        {
            var movie = _movieRepository.GetById(id);
            var movieDetails = new MovieDetailsModel
            {
                Title = movie.Title,
                Id = movie.Id,
                PosterUrl = movie.PosterUrl,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                ReleaseDate = movie.ReleaseDate,
                Overview = movie.Overview, 
                TmdbUrl = movie.TmdbUrl,
                Tagline= movie.Tagline,
                BackdropUrl = movie.BackdropUrl,
                OriginalLanguage = movie.OriginalLanguage,
                RunTime = movie.RunTime,    
                Price = movie.Price,
               
        // todo add all the properties along with rating
    };
            movieDetails.Trailers = new List<TrailerModel>();
            foreach (var trailer in movie.Trailers)
            {
                movieDetails.Trailers.Add(new TrailerModel { Id = trailer.Id, Name = trailer.Name, TrailerUrl = trailer.TrailerUrl });
            }

            // todo loop through genres and add genres model


            movieDetails.Genres = new List<GenreModel>();
            foreach (var genres in movie.GenresOfMovie)
            {
                movieDetails.Genres.Add(new GenreModel { Id = genres.GenreId, Name = genres.Genre.Name });
            }
            // todo loop through cast and add to casts model
            movieDetails.Casts = new List<CastModel>();
            foreach (var casts in movie.CastsOfMovie)
            {
                movieDetails.Casts.Add(new CastModel
                {
                    Id = casts.CastId,
                    Name = casts.Cast.Name,
                    ProfilePath = casts.Cast.ProfilePath,
                    Character = casts.Character
                });
            }

            return movieDetails;

        }
    }
}