using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TheMovie.Models;

namespace TheMovie.Controllers
{
    public class MovieController : Controller
    {
        public ActionResult Index(int? page)
        {
            string url = "https://api.themoviedb.org/3/movie/popular?api_key=3caf7633639114eb99bcb952305042f5";
            var request = System.Net.WebRequest.Create(url) as System.Net.HttpWebRequest;
            request.Method = "Get";
            request.Accept = "application/json";
            string requestResponse;
            using (var response = request.GetResponse() as System.Net.HttpWebResponse)
            {
                using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    requestResponse = reader.ReadToEnd();
                    Movies movies = JsonConvert.DeserializeObject<Movies>(requestResponse);
                    if (page > 1)
                    {
                        return View(movies.results.ToPagedList(page.Value, 5));

                    }
                    return View(movies.results.ToPagedList(1, 5));
                }

            }
        }

        public async Task<ActionResult> IndexAsync(int? page, string stringSearch)
        {
            HttpClient client = new HttpClient();
            string url = "https://api.themoviedb.org/3";
            if (stringSearch == "")
            {
                url = url + "/popular?api_key=3caf7633639114eb99bcb952305042f5";
            }
            else
            {

                url = url+ "/search/movie?api_key=3caf7633639114eb99bcb952305042f5&query=" + stringSearch;
            }
            var response = await client.GetStringAsync(url);


            Movies movies = JsonConvert.DeserializeObject<Movies>(response);
            if (page > 1)
            {
                return PartialView("indexControl", movies.results.ToPagedList(page.Value, 5));
            }
            return PartialView("indexControl", movies.results.ToPagedList(1, 5));
        }


        public ActionResult Details(int id)
        {
            string url = "https://api.themoviedb.org/3/movie/" + id + "?api_key=3caf7633639114eb99bcb952305042f5";
            var request = System.Net.WebRequest.Create(url) as System.Net.HttpWebRequest;
            request.Method = "Get";
            request.Accept = "application/json";
            string requestResponse;
            using (var response = request.GetResponse() as System.Net.HttpWebResponse)
            {
                using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    requestResponse = reader.ReadToEnd();
                    moviesResult movies = JsonConvert.DeserializeObject<moviesResult>(requestResponse);

                    return View(movies);
                }

            }
        }


    }
}