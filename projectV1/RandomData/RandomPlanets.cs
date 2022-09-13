using System;
using Bogus;
using projectV1.Models;
using System.Collections.Generic;

namespace projectV1.RandomData
{
    public static class RandomPlanets
    {
        private static List<Planet>? _planets;

        public static List<Planet> GetPlanet(int given_number)
        {
            if(_planets == null)
            {
                _planets = new Faker<Planet>()
                .RuleFor(planet => planet.Name, take => take.Name.FirstName())
                //issue in generation of unit value : we get negative values...
                .RuleFor(planet => planet.Size, take => take.Random.UInt())
                .Generate(given_number);
            }
            
            return _planets;
        }
    }
}

