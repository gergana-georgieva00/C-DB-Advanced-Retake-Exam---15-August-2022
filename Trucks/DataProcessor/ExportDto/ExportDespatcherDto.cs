using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Despatcher")]
    public class ExportDespatcherDto
    {
        public int TrucksCount { get; set; }
        public string DespatcherName { get; set; }
        public ExportTruckDto[] Trucks { get; set; }
    }

    public class ExportTruckDto
    {
        public string RegistrationNumber { get; set; }
        public string Make { get; set; }
    }
}
