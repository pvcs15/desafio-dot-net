using System;

namespace Movies.Repository
{
    public static class Url
    {
        public const string movies = "https://api.themoviedb.org/3";
        public const string moviesPopular = movies + "/movie/popular?api_key=3caf7633639114eb99bcb952305042f5";
        public const string moviesSearch = movies + "/search/movie?api_key=3caf7633639114eb99bcb952305042f5&query=";

    }
}
