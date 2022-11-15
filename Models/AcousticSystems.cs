using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_crud.Models
{
    public class AcousticSystems
    {
        public AcousticSystems()
        {
             this.EntityType = "AcousticSystems";
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Manafacturer { get; set; }
        public string EntityType { get; set; }
        //Общие характеристики
        public string Type { get; set; }
        public string Power { get; set; }
        public string MaxPower { get; set; }
        public string TheLowerLimitOfTheFrequencyRange { get; set; }
        public string TheUpperLimitOfTheFrequencyRange { get; set; }
        public string BodyMaterial { get; set; }
        public string BiAmping { get; set; }
        public string Color { get; set; }
        public string Bluetooth { get; set; }
        public string RemoteController { get; set; }
        public string NumberOfSpeakers { get; set; }
        public string Display { get; set; }
        public string FmReciver { get; set; }
        public string Interfaces { get; set; }
        public string CardReader { get; set; }
        public string Weigth { get; set; }
        public string Guarantee { get; set; }
        public string ManufacturerCountry { get; set; }
        public string ImgLink { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
