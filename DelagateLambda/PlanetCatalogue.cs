using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DelagateLambda
{
    internal class PlanetCatalogue
    {
        List<Planet> _planets = new List<Planet>();

        public delegate string PlanetValidator(string PlanetName);

        public PlanetCatalogue() 
        { 
            var planet = new Planet();

            _planets.Add(new Planet 
            { 
                Name = "Venus", 
                NumberFromSun = 2, 
                EquatorLength = 38025, 
                PrevousePlanet = _planets.Find(x => x.Name == "Mercury") 
            });

            _planets.Add(new Planet { 
                Name = "Earth", 
                NumberFromSun = 3, 
                EquatorLength = 40075, 
                PrevousePlanet = _planets.Find(x => x.Name == "Venus") 
            });

            _planets.Add(new Planet
            {
                Name = "Mars",
                NumberFromSun =4,
                EquatorLength = 38025,
                PrevousePlanet = _planets.Find(x => x.Name == "Earth")
            });
        }

        public (int NumberFromSun, int EquatorLength, string ErrorMessage) GetPlanet(string PlanetName, PlanetValidator Criteria)
        {
            Planet planet = _planets.Find(x => x.Name.ToLower() == PlanetName.ToLower());
            
            if (planet == null)
            {
                string result = Criteria(PlanetName.ToLower());

                if (!String.IsNullOrEmpty(result))
                {
                    return (0, 0, result);
                }
                else
                {
                    return (0, 0, "No planet found.");
                }                
            }

            return (planet.NumberFromSun, planet.EquatorLength, Criteria(PlanetName));
        }
    }
}
