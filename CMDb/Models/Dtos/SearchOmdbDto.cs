using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Models
{
    public class SearchOmdbDto
    {
        #region List
        public List<SearchedMovieOmdbDto> Search { get; set; } 
        #endregion

    }
}
