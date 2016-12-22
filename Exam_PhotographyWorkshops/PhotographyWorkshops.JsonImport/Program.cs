using AutoMapper;
using MassDeffect.Data;
using Newtonsoft.Json;
using PhotographyWorkshops.Data;
using PhotographyWorkshops.Dtos;
using PhotographyWorkshops.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhotographyWorkshops.JsonImport
{
    class Program
    {
        private const string CamerasPath = "../../../datasets/cameras.json";
        private const string LensesPath = "../../../datasets/lenses.json";
        private const string PhotographersPath = "../../../datasets/photographers.json";

        static void Main()
        {
            UnitOfWork unit = new UnitOfWork();
            ConfigureAutoMapper(unit);

            //  ImportLenses(unit);
            //ImportCameras(unit); //Пълни камерите по различен ред от примера, но ги пълни правилно.
            ImportPhotographers(unit);


        }

        private static void ImportPhotographers(UnitOfWork unit)
        {
            string json = File.ReadAllText(PhotographersPath);
            IEnumerable<PhotographerDto> photographersDto = JsonConvert.DeserializeObject<IEnumerable<PhotographerDto>>(json);
            foreach (var photohrapherDto in photographersDto)
            {
                //valid recod for import must contain at least photographer’s first and last name
                if (photohrapherDto.FirstName == null || photohrapherDto.LastName == null)
                {
                    Console.WriteLine("Error. Invalid data provided");
                    continue;
                }

                Photographer photographer = Mapper.Map<Photographer>(photohrapherDto);

                //    AddPhotographerCameras(photographer, unit);
                Random random = new Random();
                var cameraIndex = random.Next(1, unit.Cameras.Count() - 1);
                var camera = unit.Cameras.Find(cameraIndex);

                photographer.PrimaryCamera = camera;

                cameraIndex = random.Next(0, unit.Cameras.Count());
                camera = unit.Cameras.Find(cameraIndex);

                photographer.SecondaryCamera = camera;

                HashSet<Len> lensToAdd = new HashSet<Len>();

                foreach (int lenseId in photohrapherDto.Lenses)
                {
                    if (unit.Lenses.Find(lenseId) == null)
                    {
                        continue;
                    }

                    Len len = unit.Lenses.First(lenn => lenn.Id == lenseId);

                    if (len.CompatibleWith != photographer.PrimaryCamera.Make && len.CompatibleWith != photographer.SecondaryCamera.Make)
                    {
                        continue;
                    }

                    lensToAdd.Add(len);
                }

                photographer.Lenses = lensToAdd;

                if (photographer.FirstName == null || photographer.LastName == null)
                {
                    Console.WriteLine("Error. Invalid data provided");
                }

                try
                {
                    unit.Photographers.Add(photographer);
                    unit.Commit();
                    Console.WriteLine($"Successfully imported {photographer.FirstName} {photographer.LastName} | Lenses: {photographer.Lenses.Count()}");

                }
                catch (DbEntityValidationException ex)
                {
                    unit.Photographers.Remove(photographer);
                    unit.Commit();
                    // Console.WriteLine("Error. Invalid data provided");
                }


            }
        }

        private static void AddPhotographerCameras(Photographer photographer, UnitOfWork unit)
        {

        }

        private static void ImportCameras(UnitOfWork unit)
        {
            string json = File.ReadAllText(CamerasPath);
            IEnumerable<CameraDto> camsDtos = JsonConvert.DeserializeObject<IEnumerable<CameraDto>>(json);
            foreach (var camDto in camsDtos)
            {
                //A valid recod for import must contain at least camera’s type, make, model and minimum ISO.
                if (camDto.Type == null || camDto.Make == null || camDto.Model == null || camDto.MinIso < 100)
                {
                    Console.WriteLine("Error. Invalid data provided");
                    continue;
                }

                if (camDto.Type == "DSLR")
                {
                    DSLR_Camera camera = Mapper.Map<DSLR_Camera>(camDto);
                    if (camera.Make == null || camera.Model == null || camera.MinIso < 100)
                    {
                        Console.WriteLine("Error. Invalid data provided");
                        continue;
                    }

                    unit.Cameras.Add(camera);
                    unit.Commit();
                    Console.WriteLine($"Successfully imported DSLR {camera.Make} {camera.Model}");
                }
                else if (camDto.Type == "Mirrorless")
                {
                    MirrorlessCamera camera = Mapper.Map<MirrorlessCamera>(camDto);

                    if (camera.Make == null || camera.Model == null || camera.MinIso == 0)
                    {
                        Console.WriteLine("Error. Invalid data provided");
                        continue;
                    }

                    unit.Cameras.Add(camera);
                    unit.Commit();
                    Console.WriteLine($"Successfully imported Mirrorless {camera.Make} {camera.Model}");
                }
            }
        }

        private static void ImportLenses(UnitOfWork unit)
        {
            string json = File.ReadAllText(LensesPath);
            IEnumerable<LenDto> lensDtos = JsonConvert.DeserializeObject<IEnumerable<LenDto>>(json);
            foreach (var lenDto in lensDtos)
            {

                Len len = Mapper.Map<Len>(lenDto);
                unit.Lenses.Add(len);
                unit.Commit();
                Console.WriteLine($"Successfully imported {len.Make} {len.FocalLength}mm f{len.MaxAperture}");
            }
        }

        private static void ConfigureAutoMapper(UnitOfWork unit)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<LenDto, Len>();

                config.CreateMap<CameraDto, DSLR_Camera>();
                config.CreateMap<CameraDto, MirrorlessCamera>();

                config.CreateMap<PhotographerDto, Photographer>()
                    .ForMember(photographer => photographer.Lenses,
                        expression => expression.Ignore());
            });
        }
    }
}
