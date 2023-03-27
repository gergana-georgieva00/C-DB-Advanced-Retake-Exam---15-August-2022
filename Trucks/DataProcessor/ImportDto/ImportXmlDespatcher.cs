using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Trucks.Data.Models;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class ImportXmlDespatcher
    {
        [XmlElement("Name")]
        [Required,MinLength(2), MaxLength(40)]
        public string? Name { get; set; }

        [XmlElement("Position")]
        public string? Position { get; set; }

        [XmlArray("Trucks")]
        public TruckDto[]? Trucks { get; set; }
    }

    public class TruckDto
    {
        [XmlElement("RegistrationNumber")]
        [Required, StringLength(8), RegularExpression(@"[A-Z]{2}\d{4}[A-Z]{2})")]
        public string? RegistrationNumber { get; set; }

        [XmlElement("VinNumber")]
        [Required, StringLength(17)]
        public string? VinNumber { get; set; }

        [XmlElement("TankCapacity")]
        [Range(950, 1420)]
        public int TankCapacity  { get; set; }

        [XmlElement("CargoCapacity")]
        [Range(5000, 29000)]
        public int CargoCapacity  { get; set; }

        [XmlElement("CategoryType")]
        [Required, Range(0, 3)]
        public int CategoryType { get; set; }

        [XmlElement("MakeType")]
        [Required, Range(0, 4)]
        public int MakeType { get; set; }
    }
}
