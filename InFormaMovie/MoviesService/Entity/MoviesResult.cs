using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Service
{ 
    public class MoviesResult
    {
        public int id { get; set; }
        public string title { get; set; }
        public string vote_average { get; set; }
        public string poster_path { get; set; }
        public string overview { get; set; }
        public double vote_count { get; set; }
        public string popularity { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
    }
}
