namespace MassDeffect.ImportJSON
{
    using MassDeffect.Data;
    using DTOs;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    using Models;
    using AutoMapper;

    class Program
    {
        private const string SolarSystempath = "../../../datasets/solar-systems.json";
        private const string StarsPath = "../../../datasets/stars.json";
        private const string PlanetsPath = "../../../datasets/planets.json";
        private const string PersonsPath = "../../../datasets/persons.json";
        private const string AnomaliesPath = "../../../datasets/anomalies.json";
        private const string AnomalyVictimsPath = "../../../datasets/anomaly-victims.json";
        private const string error = "Error: Invalid data.";

        static void Main()
        {
            //MassDeffectContext context = new MassDeffectContext();
            UnitOfWork unit = new UnitOfWork();
            ConfigureAutoMapper(unit);

            //ImportSolarSystems(unit);
            //ImportStars(unit);
            //ImportPlanets(unit);
            //ImportPersons(unit);
            //ImportAnomalies(unit);
           // ImportAnomalyVictims(unit);
        }

        private static void ConfigureAutoMapper(UnitOfWork unit)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<SolarSystemDto, SolarSystem>();

                config.CreateMap<StarDto, Star>()
                    .ForMember(star => star.SolarSystem,
                            expression => expression
                                .MapFrom(dto => unit.SolarSystems
                                .First(sol => sol.Name == dto.SolarSystem)));

                config.CreateMap<PlanetDto, Planet>()
                    .ForMember(planet => planet.SolarSystem,
                        expression => expression
                            .MapFrom(dto => unit.SolarSystems
                                .First(sol => sol.Name == dto.SolarSystem)))
                    .ForMember(planet => planet.Sun,
                        expression => expression
                            .MapFrom(dto => unit.Stars
                                .First(star => star.Name == dto.Sun)));

                config.CreateMap<PersonDto, Person>()
                    .ForMember(person => person.HomePlanet,
                        expression => expression
                            .MapFrom(dto => unit.Planets
                              .First(planet => planet.Name == dto.HomePlanet)));

                config.CreateMap<AnomalyDto, Anomaly>()
                    .ForMember(Anomaly => Anomaly.OriginPlanet,
                        expression => expression
                            .MapFrom(dto => unit.Planets
                                .First(planet => planet.Name == dto.OriginPlanet)))
                    .ForMember(anomaly => anomaly.TeleportPlanet,
                        expression => expression
                            .MapFrom(dto => unit.Planets
                                .First(planet => planet.Name == dto.TeleportPlanet)));


            });
        }

        private static void ImportAnomalyVictims(UnitOfWork unit)
        {
            string json = File.ReadAllText(AnomalyVictimsPath);
            IEnumerable<AnomalyVictimDto> anomalyVictimsDto = JsonConvert.DeserializeObject<IEnumerable<AnomalyVictimDto>>(json);

            foreach (var anomalyVictimDto in anomalyVictimsDto)
            {
                if (anomalyVictimDto.Id <= 0 || anomalyVictimDto.Person == null)
                {
                    Console.WriteLine(error);
                    continue;
                }

                Anomaly anomaly = unit.Anomalies.First(anomaly1 => anomaly1.Id == anomalyVictimDto.Id);
                Person victim = unit.Persons.First(pers => pers.Name == anomalyVictimDto.Person);
                if (anomaly == null || victim == null)
                {
                    Console.WriteLine(error);
                    continue;
                }

                anomaly.Victims.Add(victim);
                unit.Commit();

               // Console.WriteLine();
            }
        }

        private static void ImportAnomalies(UnitOfWork unit)
        {
            string json = File.ReadAllText(AnomaliesPath);
            IEnumerable<AnomalyDto> anomaliesDto = JsonConvert.DeserializeObject<IEnumerable<AnomalyDto>>(json);
            foreach (var anomalyDto in anomaliesDto)
            {
                if (anomalyDto.OriginPlanet == null || anomalyDto.TeleportPlanet == null)
                {
                    Console.WriteLine(error);
                    continue;
                }

                Anomaly anomaly = Mapper.Map<Anomaly>(anomalyDto);

                if (anomaly.OriginPlanet == null || anomaly.TeleportPlanet == null)
                {
                    Console.WriteLine(error);
                    continue;
                }

                unit.Anomalies.Add(anomaly);
                unit.Commit();
                Console.WriteLine("Successfully imported anomaly.");
            }
        }

        private static void ImportPersons(UnitOfWork unit)
        {
            string json = File.ReadAllText(PersonsPath);
            IEnumerable<PersonDto> personsDtos = JsonConvert.DeserializeObject<IEnumerable<PersonDto>>(json);
            foreach (var personDto in personsDtos)
            {
                if (personDto.Name == null || personDto.HomePlanet == null)
                {
                    Console.WriteLine(error);
                    continue;
                }

                Person person = Mapper.Map<Person>(personDto);

                if (person.HomePlanet == null)
                {
                    Console.WriteLine(error);
                    continue;
                }

                unit.Persons.Add(person);
                unit.Commit();
                Console.WriteLine($"Successfully imported Person {person.Name}.");
            }
        }

        private static void ImportPlanets(UnitOfWork unit)
        {
            string json = File.ReadAllText(PlanetsPath);
            IEnumerable<PlanetDto> planetDtos = JsonConvert.DeserializeObject<IEnumerable<PlanetDto>>(json);

            foreach (var planetDto in planetDtos)
            {
                if (planetDto.Name == null || planetDto.Sun == null || planetDto.SolarSystem == null)
                {
                    Console.WriteLine(error);
                    continue;
                }

                Planet planet = Mapper.Map<Planet>(planetDto);
                if (planet.Sun == null || planet.SolarSystem == null)
                {
                    Console.WriteLine(error);
                    continue;
                }

                unit.Planets.Add(planet);
                unit.Commit();
                Console.WriteLine($"Successfully imported Planet {planet.Name}.");
            }
        }

        private static void ImportStars(UnitOfWork unit)
        {
            string json = File.ReadAllText(StarsPath);
            IEnumerable<StarDto> starDtos = JsonConvert.DeserializeObject<IEnumerable<StarDto>>(json);

            foreach (var starDto in starDtos)
            {
                if (starDto.Name == null || starDto.SolarSystem == null)
                {
                    Console.WriteLine(error);
                    continue;
                }

                Star star = Mapper.Map<Star>(starDto);
                if (star.SolarSystem == null)
                {
                    Console.WriteLine(error);
                    continue;
                }

                unit.Stars.Add(star);
                unit.Commit();
                Console.WriteLine($"Successfully imported Star {star.Name}.");
            }
        }

        private static void ImportSolarSystems(UnitOfWork unit)
        {
            string json = File.ReadAllText(SolarSystempath);
            IEnumerable<SolarSystemDto> solarSystemDtos = JsonConvert.DeserializeObject<IEnumerable<SolarSystemDto>>(json);
            foreach (var solarSystemDto in solarSystemDtos)
            {
                if (solarSystemDto.Name == null)
                {
                    Console.WriteLine(error);
                    continue;
                }

                SolarSystem solarSystem = Mapper.Map<SolarSystem>(solarSystemDto);
                unit.SolarSystems.Add(solarSystem);
                unit.Commit();
                Console.WriteLine($"Successfully imported Solar System {solarSystem.Name}.");
            }
        }
    }
}
