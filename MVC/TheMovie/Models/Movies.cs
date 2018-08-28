using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheMovie.Models
{
    public class Movies
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<moviesResult> results { get; set; }

    //public Movies()
    //    {
    //        results = new List<moviesResult>();
    //    }
    }
}