﻿using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        // business logic method that can be used to show movies on the home page
        Task<List<MovieCard>> Get30HighestGrossingMovies();

        Task<MovieDetailsModel> GetMovieDetails(int id);

        Task<List<MovieCard>> Get30HighestRatedMovies();

        Task<List<ReviewRequestModel>> GetReviewByMovieId(int id);



    }
}