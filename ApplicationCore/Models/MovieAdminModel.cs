using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class MovieAdminModel
    {

        [Required(ErrorMessage = "Title cannot be empty")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Overview cannot be empty")]
        public string? Overview { get; set; }
        public string? Tagline { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public string? ImdbUrl { get; set; }
        public string? TmdbUrl { get; set; }
        public string? PosterUrl { get; set; }
        public string? BackdropUrl { get; set; }
        public string? OriginalLanguage { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? CreatedBy { get; set; }

        public List<CastModel> Casts { get; set; }
        public List<TrailerModel> Trailers { get; set; }

        [Required(ErrorMessage = "Genre cannot be empty")]
        public List<GenreModel> Genres { get; set; }
    }
}
