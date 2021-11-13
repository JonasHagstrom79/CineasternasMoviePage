using CMDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Repositories
{
   public interface IRepository
   {
        Task<IEnumerable<TopMoviesPropertiesCmdbDto>> GetTopMoviesAsync();
        Task<TopMoviePropertiesOmdbDto> GetMovie(string name);
        Task<SearchOmdbDto> SearchResult(string searchInput); 
    }
}
