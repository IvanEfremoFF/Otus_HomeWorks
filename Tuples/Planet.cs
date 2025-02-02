using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuples
{
    internal class Planet
    {
        public string Name { get; set; }
        public int NumberFromSun { get; set; }
        public int EquatorLength { get; set; }
        public Planet? PrevousePlanet { get; set; }
    }
}
