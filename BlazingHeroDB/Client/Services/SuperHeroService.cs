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
        public List<SuperHero> Heroes { get; set; } = new();
        
        public event Action OnChange;

        public async Task GetComics()
        {
            Comics = await httpClient.GetFromJsonAsync<List<Comic>>("api/superhero/comics");
        }

        public async Task<List<SuperHero>> CreateSuperHero(SuperHero hero)
        {
            var results = await httpClient.PostAsJsonAsync("api/superhero", hero);
            Heroes = await results.Content.ReadFromJsonAsync<List<SuperHero>>();
            OnChange.Invoke();
            return Heroes;
        }

        public async Task<SuperHero> GetSuperHeroById(int id)
        {
            return await httpClient.GetFromJsonAsync<SuperHero>($"api/superhero/{id}");
        }

        public async Task<List<SuperHero>> GetSuperHeroes()
        {
            Heroes = await httpClient.GetFromJsonAsync<List<SuperHero>>("api/superhero");
            return Heroes;
        }

        public async Task<List<SuperHero>> UpdateSuperHero(SuperHero hero, int id)
        {
            var results = await httpClient.PutAsJsonAsync($"api/superhero/{id}", hero);
            Heroes = await results.Content.ReadFromJsonAsync<List<SuperHero>>();
            OnChange.Invoke();
            return Heroes;
        }
    }
}
