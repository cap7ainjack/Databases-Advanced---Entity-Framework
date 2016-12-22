using MassDeffect.Data;
using MassDeffect.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MassDeffect.ImportXML
{
    class Program
    {
        private static string AnomaliesPath = "../../../datasets/new-anomalies.xml";

        static void Main()
        {
            UnitOfWork unit = new UnitOfWork();
            ImportAnomalies(unit);

        }

        private static void ImportAnomalies(UnitOfWork unit)
        {
            XDocument xmlDocument = XDocument.Load(AnomaliesPath);
            var xmlElements = xmlDocument.Descendants("anomaly");
            foreach (var elementXml in xmlElements)
            {
                var originNamePlanetAttr = elementXml.Attribute("origin-planet");
                var teleportPlanetNametAttr = elementXml.Attribute("teleport-planet");

                if (originNamePlanetAttr == null || teleportPlanetNametAttr == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }

                Planet originPlanet = unit.Planets.First(pl => pl.Name == originNamePlanetAttr.Value);
                Planet teleportPlanet = unit.Planets.First(pl => pl.Name == teleportPlanetNametAttr.Value);

                if (originPlanet == null || teleportPlanet == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                }

                List<Person> victims = new List<Person>();
                var victimsXML = elementXml.Descendants("victim");
                foreach (var victimXML in victimsXML)
                {
                    var vicitmNameAttr = victimXML.Attribute("name");
                    if (vicitmNameAttr == null)
                    {
                        Console.WriteLine("Error: Invalid data");
                        continue;
                    }

                    Person victim = unit.Persons.First(pers => pers.Name == vicitmNameAttr.Value);
                    if (victim == null)
                    {
                        Console.WriteLine("Error: Invalid data");
                        continue;
                    }

                    victims.Add(victim);
                }

                Anomaly anomaly = new Anomaly()
                {
                    OriginPlanet = originPlanet,
                    TeleportPlanet = teleportPlanet,
                    Victims = victims
                };

                unit.Anomalies.Add(anomaly);
                unit.Commit();
                Console.WriteLine("Successfully added anomaly.");
            }

        }
    }
}
