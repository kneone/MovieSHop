﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("Genre")]
    public class Genre
    {
        public int Id { get; set; }
        
        [MaxLength(64)]
        public string Name { get; set; }

        //public ICollection<Trailer> Trailers { get; set; }
        //public ICollection<Genre> Genres{ get; set; }

        public ICollection<MovieGenre> MoviesOfGenre { get; set; }
    }
}
