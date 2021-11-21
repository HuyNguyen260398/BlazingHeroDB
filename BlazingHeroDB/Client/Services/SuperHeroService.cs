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

        public List<Comic> Comics { get; set; } = new();

        public async Task GetComics()
        {
            Comics = await httpClient.GetFromJsonAsync<List<Comic>>("api/superhero/comics");
        }

        public async Task<List<SuperHero>> CreateSuperHero(SuperHero hero)
        {
            var results = await httpClient.PostAsJsonAsync("api/superhero", hero);
            var heroes = await results.Content.ReadFromJsonAsync<List<SuperHero>>();
            return heroes;
        }

        public async Task<SuperHero> GetSuperHeroById(int id)
        {
            return await httpClient.GetFromJsonAsync<SuperHero>($"api/superhero/{id}");
        }

        public async Task<List<SuperHero>> GetSuperHeroes()
        {
            return await httpClient.GetFromJsonAsync<List<SuperHero>>("api/superhero");
        }
    }
}
