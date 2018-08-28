using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheMovie.Models
{
    public class moviesResult
    {
        public int id { get; set; }
        public string title { get; set; }
        public string vote_average { get; set; }
        public string poster_path { get; set; }
        public string overview { get; set; }
    }
}