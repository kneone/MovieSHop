﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class FavoriteRequestModel
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }

       
    }
}
