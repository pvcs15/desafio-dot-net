using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class MoviesModel
    {

        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<MoviesResultModel> results { get; set; }
    }
}