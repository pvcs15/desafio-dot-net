using System;
using System.Collections.Generic;

namespace Movies.Service
{
    public class Movies
    {

        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<MoviesResult> results { get; set; }
    }
}