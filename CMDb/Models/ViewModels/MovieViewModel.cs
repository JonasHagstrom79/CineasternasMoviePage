using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Models.ViewModels
{
    public class MovieViewModel : TopMoviePropertiesOmdbDto
    {
        #region List
        public List<TopMoviesPropertiesCmdbDto> topmoviescmdb;
        #endregion

        #region Properties
        public TopMoviePropertiesOmdbDto moviedetails { get; set; }
        public string id { get; set; }
        #endregion

        #region Constructors
        public MovieViewModel(IEnumerable<TopMoviesPropertiesCmdbDto> topmoviescmdb, TopMoviePropertiesOmdbDto moviedetails, string id)
        {
            this.topmoviescmdb = topmoviescmdb.ToList();
            this.moviedetails = moviedetails;
            this.id = id;
            this.Title = moviedetails.Title;
            this.Actors = moviedetails.Actors;
            this.Poster = moviedetails.Poster;
            this.Plot = moviedetails.Plot;
            this.Poster = moviedetails.Poster;
            this.Metascore = moviedetails.Metascore;
            this.ImdbRating = moviedetails.ImdbRating;
            this.Year = moviedetails.Year;
            this.Released = moviedetails.Released;
            this.Runtime = moviedetails.Runtime;
            this.Genre = moviedetails.Genre;
            this.Director = moviedetails.Director;
            this.Writer = moviedetails.Writer;
            this.Country = moviedetails.Country;
            this.Awards = moviedetails.Awards;
            GetLikesAndDislikesForMovie();
        }
        public MovieViewModel()
        {

        } 
        #endregion

        #region Methods
        /// <summary>
        /// Hämtar Likes och Dislikes från en film
        /// </summary>
        public void GetLikesAndDislikesForMovie()
        {
            for (int i = 0; i < topmoviescmdb.Count; i++)
            {
                if (topmoviescmdb[i].ImdbID == id)
                {
                    this.NumberOfLikes = topmoviescmdb[i].NumberOfLikes;
                    this.NumberOfDislikes = topmoviescmdb[i].NumberOfDislikes;
                }


            }

        } 
        #endregion

    }

}


