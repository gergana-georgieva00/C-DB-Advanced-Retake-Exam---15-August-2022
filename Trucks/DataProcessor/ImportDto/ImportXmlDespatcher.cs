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

        public string? Position { get; set; }
        public ICollection<Truck> Trucks { get; set; }
    }
}
