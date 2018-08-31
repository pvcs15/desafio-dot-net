using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Repository
{
    public class MoviesRepository
    {
        public string Popular()
        {
            var request = System.Net.WebRequest.Create(Url.moviesPopular) as System.Net.HttpWebRequest;
            request.Method = "Get";
            request.Accept = "application/json";
            string requestResponse;
            using (var response = request.GetResponse() as System.Net.HttpWebResponse)
            {
                using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    requestResponse = reader.ReadToEnd();
                    return requestResponse;
                }

            }
        }

        public async Task<string> Search(string stringSearch)
        {
            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync(string.IsNullOrEmpty(stringSearch) ? Url.moviesPopular : Url.moviesSearch + stringSearch);

            return response;
        }
        public string Details(int id)
        {
            var urlDetails = Url.movies + "/movie/" + id + "?api_key=3caf7633639114eb99bcb952305042f5";
            var request = System.Net.WebRequest.Create(urlDetails) as System.Net.HttpWebRequest;
            request.Method = "Get";
            request.Accept = "application/json";
            string requestResponse;
            using (var response = request.GetResponse() as System.Net.HttpWebResponse)
            {
                using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    requestResponse = reader.ReadToEnd();
                    return requestResponse;
                }

            }
        }
    }

}