using MassDeffect.Data;
using PhotographyWorkshops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PhotographyWorkshops.XmlImport
{
    class Program
    {
        private static string accessoryPath = "../../../datasets/accessories.xml";
        private static string workshopsPath = "../../../datasets/workshops.xml";
        
        static void Main()
        {
            UnitOfWork unit = new UnitOfWork();
            ImportAccessory(unit);

            ImportWorkshops(unit);
        }

        private static void ImportWorkshops(UnitOfWork unit)
        {
            XDocument xmlDocument = XDocument.Load(workshopsPath);
            var xmlElements = xmlDocument.Descendants("workshop");


        }

        private static void ImportAccessory(UnitOfWork unit)
        {
            XDocument xmlDocument = XDocument.Load(accessoryPath);
            var xmlElements = xmlDocument.Descendants("accessory");

            foreach (var elementXml in xmlElements)
            {
                var AccessoryNameAtt = elementXml.Attribute("name").Value;
                Random random = new Random();
                //  int randIndex = random.Next(1, unit.Photographers.Count() - 1);

                // var photographer = unit.Photographers.Find(randIndex);

                // Иимпорта на фотографи е счупен
                Accessory accessory = new Accessory
                {
                    Name = AccessoryNameAtt
                    // Owner = photographer
                };

                unit.Accessories.Add(accessory);
                unit.Commit();
                Console.WriteLine($"Successfully imported {accessory.Name}");


            }
        }
    }
}


