using System;
using Bogus.DataSets;
using Microsoft.AspNetCore.Mvc;
using projectV1.Models;
using projectV1.RandomData;

namespace projectV1.Controllers
{
    [Route("[controller]")]
    //Data to display when the url is "http://localhost:5246/systems" :
    public class SystemsController : Controller
    {
        List<Models.System> systems = new List<Models.System>() {
        new Models.System()
        {
            Name = "System1",
            planets = RandomPlanets.GetPlanet(5)
        },

        new Models.System()
        {
            Name = "System2",
            planets = RandomPlanets.GetPlanet(5)
        }

    };
        //Fetch all data in the url "http://localhost:5246/systems" : OK
        [HttpGet]
        public List<Models.System> GetAllData(string Name)
        {
            return systems;
        }

        //Fetch a single system, and all its planets in the url "http://localhost:5246/systems/'givensystemName'" : OK
        [HttpGet("{systemName}")]
        public Models.System GetDataOfSystem(string systemName)
        {
            var askSystem = systems.Find(x => x.Name == systemName);
            return askSystem;
        }

        //Fetch all planets of a single system in the url "http://localhost:5246/systems/'givensystemName'/planets/'givensystemName'" : OK
        [HttpGet("{systemName}/planets")]
        public List<Planet> GetPlanets(string systemName)
        {
            var askPlanetsOfSystem = systems.FirstOrDefault(x => x.Name == systemName);
            return askPlanetsOfSystem.planets;
        }

       
        //Fetch a single planet of a system in the url "http://localhost:5246/systems/'givensystemName'/planets/'givensystemName'" : OK
        [HttpGet("{systemName}/planets/{planetName}")]
        public Planet GetSinglePlanet(string systemName, string planetName)
        {
            var askOneSystem = systems.FirstOrDefault(x => x.Name == systemName);
            var askOnePlanet = askOneSystem.planets.FirstOrDefault(y => y.Name == planetName);
            return askOnePlanet;
        }
        
    }


}