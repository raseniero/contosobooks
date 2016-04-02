using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoBooks.Models
{
    public class  Movie
    {
        [ScaffoldColumn(false)]
        public int MovieID { get; set; }
        public string Title { get; set; }
        public DateTime  ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }    
}
