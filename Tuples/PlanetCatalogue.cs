﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tuples
{
    internal class PlanetCatalogue
    {
        List<Planet> _planets = new List<Planet>();
        private byte requestQty = 3;
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

        public (int NumberFromSun, int EquatorLength, string ErrorMessage) GetPlanet(string PlanetName)
        {
            Planet? planet = _planets.Find(x => x.Name.ToLower() == PlanetName.ToLower());
            string message = "";

            requestQty--;

            if (planet == null)
                return (0, 0, "No planet found.");

            if (requestQty == 0)
            {
                requestQty = 3;
                return (0, 0, "You're asking too often.");
            }

            return (planet.NumberFromSun, planet.EquatorLength, message);
        }
    }
}
