using CMDb.Models;
using CMDb.Models.ViewModels;
using CMDb.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Controllers
{
    
    public class HomeController : Controller
    {
        List<TopMoviePropertiesOmdbDto> omdbmovies = new List<TopMoviePropertiesOmdbDto>();
        private readonly IRepository repository;
        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var tasks = new List<Task>();
                var topmovies = await repository.GetTopMoviesAsync();//Hämtar toplistan från Cineasternas databas
                topmovies.OrderBy(topmovie => topmovie.NumberOfLikes);
                foreach (var topmovie in topmovies)
                {
                    if(tasks.Count == 25)// Vi hämtar bara in antalet nödvändiga filmer på första sidan för att minska laddningstiden plus 5 för att undvika kraschar. 
                    {
                        break;
                    }
                    tasks.Add(
                        Task.Run(
                            async () =>
                            {
                                var movie = await repository.GetMovie(topmovie.ImdbID);//Hämtar topfilmen från Omdb
                                movie.NumberOfDislikes = topmovie.NumberOfDislikes;
                                movie.NumberOfLikes = topmovie.NumberOfLikes;
                                omdbmovies.Add(movie);                         
                            }
                        ));
                }
                await Task.WhenAll(tasks);//Klar       
                var model = new HomeViewModel(omdbmovies);
                return View(model);//Skickar informationen
            }
            catch (System.Exception)//För felhantering
            {
                var model = new HomeViewModel();
                ModelState.AddModelError(string.Empty, "No contact with Api");
                return View(model);
                throw;

            }

        }
    }
}
