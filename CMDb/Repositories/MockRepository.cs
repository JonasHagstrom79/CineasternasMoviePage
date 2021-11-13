using CMDb.Infrastructur;
using CMDb.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Repositories
{
    public class MockRepository : IRepository
    {
        private readonly IApiClient apiClient;
        private readonly string basePath;
        private readonly string baseEndpoint1 = "http://www.omdbapi.com/?apikey=13205a1b&i=";
        private readonly string baseSearch = "http://www.omdbapi.com/?apikey=80a9e33f&s=";
        public MockRepository(IApiClient apiClient, IWebHostEnvironment environment)
        {
            this.apiClient = apiClient;
            basePath = $@"{environment.ContentRootPath}\Mock\";
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
        /// Hämtar Toppplistan från Cineasternas databas
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TopMoviesPropertiesCmdbDto>> GetTopMoviesAsync()
        {
            await Task.Delay(0);
            return GetTestData<IEnumerable<TopMoviesPropertiesCmdbDto>>("cmdb.json");
        }
        /// <summary>
        /// Sökfunktion för Omdb
        /// </summary>
        /// <param name="searchInput"></param>
        /// <returns></returns>
        public async Task<SearchOmdbDto> SearchResult(string searchInput)
        {
            return await apiClient.GetAsync<SearchOmdbDto>($"{baseSearch}{searchInput}");
        }

        private T GetTestData<T>(string testfile)
        {
            var path = $"{basePath}{testfile}";
            string data = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
