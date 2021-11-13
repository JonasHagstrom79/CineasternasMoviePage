using CMDb.Infrastructur;
using CMDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Repositories
{
    public class Repository : IRepository
    {

        private readonly IApiClient apiClient;
        private readonly string baseEndpoint = "https://grupp9.dsvkurs.miun.se";
        private readonly string baseEndpoint1 = "http://www.omdbapi.com/?apikey=13205a1b&i=";
        private readonly string baseSearch = "http://www.omdbapi.com/?apikey=80a9e33f&s=";
        public Repository(IApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        /// <summary>
        /// Hämtar en film från Omdb
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<TopMoviePropertiesOmdbDto> GetMovie(string name)
        {
            return await apiClient.GetAsync<TopMoviePropertiesOmdbDto>($"{baseEndpoint1}{name}");
        }

        /// <summary>
        /// Hämtar Topplistan från Cineasternas databas
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TopMoviesPropertiesCmdbDto>> GetTopMoviesAsync()//Här
        {
           return await apiClient.GetAsync<IEnumerable<TopMoviesPropertiesCmdbDto>>($"{baseEndpoint}/api/Toplist");
        }

        /// <summary>
        /// Sökfunktion för Omdb
        /// </summary>
        /// <param name="searchInput"></param>
        /// <returns></returns>
        public async Task<SearchOmdbDto> SearchResult(string searchInput) //Fungerar, ger en lista med sökningen
        {
            return await apiClient.GetAsync<SearchOmdbDto>($"{baseSearch}{searchInput}");
        }        
    }
}
