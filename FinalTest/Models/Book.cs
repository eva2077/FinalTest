using System;
using System.ComponentModel.DataAnnotations;

namespace FinalTest.Models
{
    public class Book
    {


        [Key]

        public int BookID { get; set; } //If you want a read only just do get: ex like this: public string RecipeID { get; }

        [Required]
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public int ISBN { get; set; }
        public string? Classification { get; set; }
        public string? Category { get; set; }
        public int PageCount { get; set; }
        public int Price { get; set; }

    }
}

