namespace test_crud.Models
{
    public class Microphones
    {

        public Microphones()
        {
            this.EntityType = "Microphones";
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Manafacturer { get; set; }
        public string EntityType { get;set; }
        //Общие характеристики
        public string Type { get; set; }
        public string TheLowerLimitOfTheFrequencyRange { get; set; }
        public string TheUpperLimitOfTheFrequencyRange { get; set; }
        public string Connection { get; set; }
        public string WirelessInterface { get; set; }
        public string BodyMaterial { get; set; }
        public string Color { get; set; }
        public string Equipment { get; set; }
        public string Weigth { get; set; }
        public string Guarantee { get; set; }
        public string ManufacturerCountry { get; set; }
        public string ImgLink { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
