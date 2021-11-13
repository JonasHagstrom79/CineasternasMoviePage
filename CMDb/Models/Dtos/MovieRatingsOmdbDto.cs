using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Models
{
    public class MovieRatingsOmdbDto
    {
        #region List
        public List<TopMoviePropertiesOmdbDto> TopMovieList { get; set; } 
        #endregion
    }
}
