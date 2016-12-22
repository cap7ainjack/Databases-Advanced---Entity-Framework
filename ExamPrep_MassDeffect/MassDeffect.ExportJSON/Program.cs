using MassDeffect.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDeffect.ExportJSON
{
    class Program
    {
        static void Main()
        {
            UnitOfWork unit = new UnitOfWork();

            // ExportPlanetsWithAreNotAnomalyOrigins(unit);
            // ExportPeopleWichHaveNotBeenVictims(unit);
            ExportTopAnomaly(unit);

        }

        private static void ExportTopAnomaly(UnitOfWork unit)
        {
            var anomalies = unit.Anomalies.GetAll().OrderByDescending(anomaly => anomaly.Victims.Count)
                .Take(1)
                .Select(anomaly => new
                {
                    id = anomaly.Id,
                    OriginPlanet = new
                    {
                        name = anomaly.OriginPlanet.Name
                    },
                    TeleportPlanet = new
                    {
                        name = anomaly.TeleportPlanet.Name
                    },
                    VictimsCount = anomaly.Victims.Count()
                });

            string json = JsonConvert.SerializeObject(anomalies, Formatting.Indented);

            File.WriteAllText("../../../export/TopAnomaly.json", json);
        }

        private static void ExportPeopleWichHaveNotBeenVictims(UnitOfWork unit)
        {
            var people = unit.Persons
                    .GetAll(person => person.Anomalies.Count == 0)
                    .Select(person => new
                    {
                        person.Name,
                        homePlanet = new
                        {
                            person.HomePlanet.Name
                        }
                    });

            string json = JsonConvert.SerializeObject(people, Formatting.Indented);

            File.WriteAllText("../../../export/peopleNotBeenVictims.json", json);

        }

        private static void ExportPlanetsWithAreNotAnomalyOrigins(UnitOfWork unit)
        {
            var planets = unit.Planets
                            .GetAll(planet => planet.OriginAnomalies.Count == 0)
                            .Select(planet => planet.Name);
            string json = JsonConvert.SerializeObject(planets, Formatting.Indented);

            File.WriteAllText("../../../export/planetsNotOriginAnomalies.json", json);

        }
    }
}
