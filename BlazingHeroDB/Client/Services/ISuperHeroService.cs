using BlazingHeroDB.Shared;

namespace BlazingHeroDB.Client.Services
{
    public interface ISuperHeroService
    {
        event Action OnChange;
        List<Comic> Comics { get; set; }
        List<SuperHero> Heroes { get; set; }
        Task GetComics();
        Task<List<SuperHero>> CreateSuperHero(SuperHero hero);
        Task<List<SuperHero>> GetSuperHeroes();
        Task<SuperHero> GetSuperHeroById(int id);
    }
}
