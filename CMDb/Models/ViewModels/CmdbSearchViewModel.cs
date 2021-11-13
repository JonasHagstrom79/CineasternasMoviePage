using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Models.ViewModels
{
    public class CmdbSearchViewModel: MovieRatingsOmdbDto
    {
        #region Object
        public TopMoviePropertiesOmdbDto FakeMovie = new TopMoviePropertiesOmdbDto();
        #endregion

        #region Constructors
        public CmdbSearchViewModel(List<TopMoviePropertiesOmdbDto> topmoviesomdb, String searchinput)
        {
            //Sorterar sökresultatet
            this.TopMovieList = topmoviesomdb.Where
            (x => x.Title.Contains(searchinput) ||
            x.Title.Contains(searchinput.ToUpper()) ||
            x.Title.Contains(searchinput.ToLower()) ||
            x.Title.Contains(char.ToUpper(searchinput[0]).ToString() + (searchinput.Substring(1))) ||
            x.Title.Contains(char.ToLower(searchinput[0]).ToString() + (searchinput.Substring(1)))).ToList();
            IsListNull();
        }
        public CmdbSearchViewModel()//För att hantera fel i controllern
        {

        } 
        #endregion

        #region Methods

        /// <summary>
        /// Skapar ett objekt om lita är tom
        /// </summary>
        private void IsListNull()
        {
            if (TopMovieList.Count == 0)
            {
                FakeMovie.ImdbID = "";
                FakeMovie.Title = "";
                FakeMovie.Poster = "";
                TopMovieList.Add(FakeMovie);
            }
        } 
        #endregion

    }
}
