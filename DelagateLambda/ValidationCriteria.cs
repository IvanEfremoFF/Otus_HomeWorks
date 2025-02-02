using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelagateLambda
{
    internal static class ValidationCriteria
    {
        private static byte NumberOfValidations = 0;

        public static string RequestReached(string PlanetName) 
        {
            NumberOfValidations++;

            if (NumberOfValidations == 3)
            {
                NumberOfValidations = 0;
                return "You're asking too often.";
            }
            return "";
        }

        public static string LemoniaPlanet(string PlanetName)
        {
            return PlanetName == "lemonia" ? "Lemonia is forbidden planet!" : "";
        }
    }
}
