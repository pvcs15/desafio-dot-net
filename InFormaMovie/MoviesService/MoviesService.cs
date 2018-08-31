using Movies.Repository;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Movies.Service
{
    public class MoviesService
    {

        private MoviesRepository repoMovies;
        public MoviesService(MoviesRepository repoMovies)
        {
            this.repoMovies = repoMovies;
        }
        public async Task<Movies> Search(string stringSearch)
        {
            var result = await repoMovies.Search(stringSearch);
            Movies movies = JsonConvert.DeserializeObject<Movies>(result);
            return movies;
        }

        public object Populate()
        {
            Movies movies = JsonConvert.DeserializeObject<Movies>(repoMovies.Popular());
            return movies;


        }
        public object Details(int id)
        {
            MoviesResult moviesResult = JsonConvert.DeserializeObject<MoviesResult>(repoMovies.Details(id));
            return moviesResult;
        }
    }
}
