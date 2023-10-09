namespace Starwars.Swapi.Domain;

public static class Constants
{
    public static class Api
    {
        public const string Url = "https://swapi.dev/api/";
        public static class Resources
        {
            public const string Films = "films";
            public const string People = "people";
            public const string Planets = "planets";
            public const string Species = "species";
            public const string Starships = "starships";
            public const string Vehicles = "vehicles";
        }
    }
    public static class Cache
    {
        public const string KeyEntry = "Cache";
    }
}