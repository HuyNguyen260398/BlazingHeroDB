using BlazingHeroDB.Shared;

namespace BlazingHeroDB.Client.Services
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetSuperHeroes();
    }
}
