﻿using System;
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
        [Required, MaxLength(8), RegularExpression(@"[A-Z]{2}\d{4}[A-Z]{2})")]
        public string RegistrationNumber { get; set; }
    }
}
