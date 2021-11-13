using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMDb.Models;
using CMDb.Models.ViewModels;
using CMDb.Repositories;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CMDb.Controllers
{
    public class CmdbSearchController : Controller
    {
        List<TopMoviePropertiesOmdbDto> movies = new List<TopMoviePropertiesOmdbDto>();
        private readonly IRepository repository;

        public CmdbSearchController(IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CmdbSearchResult(string searchInput)//Söker efter filmer i Cineasternas databas
        {
            try
            {
                var tasks = new List<Task>();
                var topmovies = await repository.GetTopMoviesAsync();//Hämtar en lista från Cineasternas api
                foreach (var topmovie in topmovies)
                {
                    tasks.Add(
                        Task.Run(
                            async () =>
                            {
                                var movie = await repository.GetMovie(topmovie.ImdbID);//Hämtar topfilmen från Omdb
                                if (movie.Title != null && movie.ImdbID != null)//För att undvika att felaktiga filmer läggs till i listan
                                {
                                    movies.Add(movie);
                                }
                            }
                        ));

                }
                await Task.WhenAll(tasks);//Klar

                var model = new CmdbSearchViewModel(movies, searchInput);
                return View("Index", model);//Skickar informationen
            }
            catch (System.Exception)//För felhantering
            {
                var model = new CmdbSearchViewModel();
                ModelState.AddModelError(string.Empty, "No contact with Api");
                return View(model);
                throw;

            }

        }
    }
}
