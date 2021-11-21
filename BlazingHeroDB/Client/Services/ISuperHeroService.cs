﻿using BlazingHeroDB.Shared;

namespace BlazingHeroDB.Client.Services
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> CreateSuperHero(SuperHero hero);
        Task<List<SuperHero>> GetSuperHeroes();
        Task<SuperHero> GetSuperHeroById(int id);
    }
}
