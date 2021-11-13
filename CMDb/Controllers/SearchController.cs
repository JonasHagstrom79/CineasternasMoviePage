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
    public class SearchController : Controller
    {
        private readonly IRepository repository;
        public SearchController(IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SearchResult(string searchInput)
        {
            try
            { 
                var task1 = repository.SearchResult(searchInput);//Söker filmer i Omdb baserat på searchinput
                await Task.WhenAll(task1);
                var movies = await task1;
                var model = new SearchViewModel(movies);
                return View("Index", model);//Skickar informationen

            }
            catch (System.Exception)//För felhantering
            {
                var model = new SearchViewModel();
                ModelState.AddModelError(string.Empty, "No contact with Api");
                return View(model);
                throw;

            }
        }
    }
}
