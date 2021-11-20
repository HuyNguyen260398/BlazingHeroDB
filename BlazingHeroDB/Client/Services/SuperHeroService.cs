using BlazingHeroDB.Shared;
using System.Net.Http.Json;

namespace BlazingHeroDB.Client.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient httpClient;

        public SuperHeroService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<SuperHero>> GetSuperHeroes()
        {
            return await httpClient.GetFromJsonAsync<List<SuperHero>>("api/superhero");
        }
    }
}
