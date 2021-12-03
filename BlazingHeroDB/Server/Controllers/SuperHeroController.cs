using BlazingHeroDB.Server.Data;
using BlazingHeroDB.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingHeroDB.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        static List<Comic> comics = new()
        {
            new Comic() { Id = 1, Name = "Marvel" },
            new Comic() { Id = 2, Name = "DC" }
        };

        static List<SuperHero> heroes = new()
        {
            new SuperHero() { Id = 1, FirstName = "Peter", LastName = "Parker", HeroName = "Spiderman", Comic = comics[0] },
            new SuperHero() { Id = 2, FirstName = "Bruce", LastName = "Wayne", HeroName = "Batman", Comic = comics[1] },
        };
        private readonly DataContext db;

        public SuperHeroController(DataContext db)
        {
            this.db = db;
        }

        [HttpGet("comics")]
        public async Task<IActionResult> GetComics()
        {
            //return Ok(comics);

            return Ok(await db.Comics.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateSuperHero(SuperHero hero)
        {
            //hero.Id = heroes.Max(x => x.Id + 1);
            //heroes.Add(hero);
            //return Ok(heroes);

            db.SuperHeroes.Add(hero);
            await db.SaveChangesAsync();
            return Ok(await GetDbHeroes());
        }

        [HttpGet]
        public async Task<IActionResult> GetSuperHeroes()
        {
            //return Ok(heroes);

            return Ok(await GetDbHeroes());
        }

        private async Task<List<SuperHero>> GetDbHeroes()
        {
            return await db.SuperHeroes.Include(c => c.Comic).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSuperHeroById(int id)
        {
            //var hero = heroes.FirstOrDefault(h => h.Id == id);
            //if (hero == null)
            //    return NotFound($"Couldn't found hero with id {id}");
            //return Ok(hero);

            var hero = await db.SuperHeroes
                               .Include(c => c.Comic)
                               .FirstOrDefaultAsync(s => s.Id == id);
            if (hero == null)
                return NotFound($"Couldn't found hero with id {id}");
            return Ok(hero);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSuperHero(SuperHero hero, int id)
        {
            //var dbHero = heroes.FirstOrDefault(h => h.Id == id);
            //if (dbHero == null)
            //    return NotFound($"Couldn't found hero with id {id}");

            //var index = heroes.IndexOf(dbHero);
            //heroes[index] = hero;
            //return Ok(heroes);

            var dBhero = await db.SuperHeroes
                               .Include(c => c.Comic)
                               .FirstOrDefaultAsync(s => s.Id == id);
            if (dBhero == null)
                return NotFound($"Couldn't found hero with id {id}");

            dBhero.FirstName = hero.FirstName;
            dBhero.LastName = hero.LastName;
            dBhero.HeroName = hero.HeroName;
            dBhero.ComicId = hero.ComicId;

            await db.SaveChangesAsync();
            return Ok(await GetDbHeroes());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuperHero(int id)
        {
            //var dbHero = heroes.FirstOrDefault(h => h.Id == id);
            //if (dbHero == null)
            //    return NotFound($"Couldn't found hero with id {id}");

            //heroes.Remove(dbHero);
            //return Ok(heroes);

            var hero = await db.SuperHeroes
                               .Include(c => c.Comic)
                               .FirstOrDefaultAsync(s => s.Id == id);
            if (hero == null)
                return NotFound($"Couldn't found hero with id {id}");

            db.SuperHeroes.Remove(hero);
            await db.SaveChangesAsync();
            return Ok(await GetDbHeroes());
        }
    }
}
