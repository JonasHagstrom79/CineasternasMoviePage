using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Models.ViewModels
{
    public class SearchViewModel : SearchOmdbDto
    {
        SearchedMovieOmdbDto FakeMovie { get; set; } = new SearchedMovieOmdbDto();

        #region Constructors
        public SearchViewModel(SearchOmdbDto searchForMovies)
        {
            IsListNull(searchForMovies);      
            this.Search = searchForMovies.Search.ToList();

        }
        public SearchViewModel()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Lägger till ett objekt om sökningen är null
        /// </summary>
        /// <param name="searchForMovies"></param>
        /// <param name="searchedmovie"></param>
        private void IsListNull(SearchOmdbDto searchForMovies)
        {
            if (searchForMovies.Search == null)
            {
                searchForMovies.Search = new List<SearchedMovieOmdbDto>();
                FakeMovie.imdbID = "";
                FakeMovie.Poster = "";
                FakeMovie.Title = "";
                searchForMovies.Search.Add(FakeMovie);
            }
        } 
        #endregion

    }
}
