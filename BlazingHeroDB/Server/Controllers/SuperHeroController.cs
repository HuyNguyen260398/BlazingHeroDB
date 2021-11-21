using BlazingHeroDB.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazingHeroDB.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        static List<Comic> comics = new()
        {
            new Comic() { Name = "Marvel" },
            new Comic() { Name = "DC" }
        };

        List<SuperHero> heroes = new()
        {
            new SuperHero() { Id = 1, FirstName = "Peter", LastName = "Parker", HeroName = "Spiderman", Comic = comics[0] },
            new SuperHero() { Id = 2, FirstName = "Bruce", LastName = "Wayne", HeroName = "Batman", Comic = comics[1] },
        };

        [HttpPost]
        public async Task<IActionResult> CreateSuperHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpGet]
        public async Task<IActionResult> GetSuperHeroes()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSuperHeroById(int id)
        {
            var hero = heroes.FirstOrDefault(h => h.Id == id);
            if (hero == null)
                return NotFound($"Couldn't found hero with id {id}");
            return Ok(hero);
        }
    }
}
