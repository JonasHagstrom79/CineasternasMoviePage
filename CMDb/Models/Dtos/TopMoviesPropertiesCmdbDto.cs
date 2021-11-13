using System;
using System.Collections.Generic;
using System.Linq;                                              
using System.Threading.Tasks;

namespace CMDb.Models
{
    public class TopMoviesPropertiesCmdbDto
    {
        #region Properties
        public string ImdbID { get; set; }
        public int NumberOfLikes { get; set; }
        public int NumberOfDislikes { get; set; } 
        #endregion

    }
}
