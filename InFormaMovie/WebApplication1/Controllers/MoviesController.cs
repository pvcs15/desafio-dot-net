using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.Service;
using Newtonsoft.Json;
using WebApplication1.Models;
using X.PagedList;

namespace WebApplication1.Controllers
{
    //[Route("Movies")]
    public class MoviesController : Controller
    {
        private MoviesService serviceMovies;
        public MoviesController(MoviesService serviceMovies)
        {
            this.serviceMovies = serviceMovies;
        }

        [HttpGet]
        public IActionResult Index(int? page)
        {
            var movies = serviceMovies.Populate();
            MoviesModel moviesModel = Mapper.Map<MoviesModel>(movies);

            if (page > 1)
            {
                return View(moviesModel.results.ToPagedList(page.Value, 5));

            }
            return View(moviesModel.results.ToPagedList(1, 5));

        }
        [HttpPost("IndexAsync")]
        [Route("/IndexAsync")]
        public async Task<IActionResult> IndexAsync(int? page, string stringSearch)
        {

            MoviesModel moviesModel = new MoviesModel();
            if (stringSearch != "")
            {
                var movies = await serviceMovies.Search(stringSearch);
                moviesModel = Mapper.Map<MoviesModel>(movies);
            }
            else
            {
                var movies = serviceMovies.Populate();
                moviesModel = Mapper.Map<MoviesModel>(movies);
            }
            if (page > 1)
            {
                return PartialView("IndexAsync", moviesModel.results.ToPagedList(page.Value, 5));

            }
            return PartialView("IndexAsync",moviesModel.results.ToPagedList(1, 5));

        }
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var moviesResult = serviceMovies.Details(id);
            MoviesResultModel moviesResultModel = Mapper.Map<MoviesResultModel>(moviesResult);
            return View(moviesResultModel);
        }

    }
}

