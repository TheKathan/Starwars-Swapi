﻿namespace Starwars.Swapi.Domain.Models;

public class Person 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Height { get; set; }
    public string Mass { get; set; }
    public string HairColor { get; set; }
    public string SkinColor { get; set; }
    public string EyeColor { get; set; }
    public string BirthYear { get; set; }
    public string Gender { get; set; }
    public Planet? Homeworld { get; set; }
    public IEnumerable<Film> Films { get; set; }
    public IEnumerable<Specie> Species { get; set; }
    public IEnumerable<Vehicle> Vehicles { get; set; }
    public IEnumerable<Starship> Starships { get; set; }
    public string Created { get; set; }
    public string Edited { get; set; }
    public string Url { get; set; }
}

