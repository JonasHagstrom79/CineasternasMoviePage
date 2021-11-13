using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Models.ViewModels
{
    public class HomeViewModel : MovieRatingsOmdbDto
    {

        #region Properties
        public string FirstHalfPlot { get; set; }
        public string SecondHalfPlot { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Gör plot för film synlig till hälften
        /// </summary>
        /// <param name="plot"></param>
        private void DimPlot(string plot)
        {
            FirstHalfPlot = plot.Substring(0, (int)(plot.Length / 2));
            SecondHalfPlot = plot.Substring((int)(plot.Length / 2), (int)(plot.Length / 2));
        }
        #endregion

        #region Constructors
        public HomeViewModel(List<TopMoviePropertiesOmdbDto> omdbmovielist)
        {
            this.TopMovieList = omdbmovielist.OrderByDescending(movie => movie.NumberOfLikes).ThenBy(movie => movie.NumberOfDislikes).ToList(); //Sorterar listan
            DimPlot(TopMovieList[0].Plot);

        }

        public HomeViewModel()//För att hantera fel i controllern
        {

        } 
        #endregion

    }
}
