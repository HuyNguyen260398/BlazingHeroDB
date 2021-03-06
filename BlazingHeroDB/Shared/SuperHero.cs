namespace BlazingHeroDB.Shared
{
    public class SuperHero
    {
        public int Id { get; set; } = 0;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HeroName { get; set; }
        public int ComicId { get; set; }
        public Comic? Comic { get; set; }
    }
}
