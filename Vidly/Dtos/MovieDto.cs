﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="please Enter the Movie Name ")]
        public string Name { get; set; }
       
         public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }


        public DateTime DateAdded { get; set; }

        public DateTime ReleaseDate { get; set; }


        [Range(1,20)]
        public byte NumberInStock { get; set; }
    }
}