namespace Trucks.DataProcessor
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            var despatcherDtos = Deserialize<ImportXmlDespatcher[]>(xmlString, "Despatchers");
            var sb = new StringBuilder();
            var despatchers = new List<Despatcher>();

            foreach (var dto in despatcherDtos)
            {
                if (!IsValid(dto) || string.IsNullOrEmpty(dto.Position))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var despatcher = new Despatcher()
                {
                    Name = dto.Name,
                    Position = dto.Position
                };

                var trucks = new List<Truck>();
                foreach (var truckDto in dto.Truck)
                {

                }
            }

            return sb.ToString();
        }

        private static T Deserialize<T>(string inputXml, string rootName)
        {
            var root = new XmlRootAttribute(rootName);
            var serializer = new XmlSerializer(typeof(T), root);

            using StringReader reader = new StringReader(inputXml);

            T dtos = (T)serializer.Deserialize(reader);
            return dtos;
        }

        public static string ImportClient(TrucksContext context, string jsonString)
        {
            var clientDtos = JsonConvert.DeserializeObject<ImportJsonClient[]>(jsonString);

            var sb = new StringBuilder();

            var clients = new List<Client>();
            var clientsTrucks = new List<ClientTruck>();

            foreach (var clientDto in clientDtos)
            {
                if (!IsValid(clientDto) || clientDto.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage); continue;
                }

                var client = new Client()
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type
                };

                foreach (var truckId in clientDto.Trucks.Distinct())
                {
                    var truck = context.Trucks.FirstOrDefault(t => t.Id == truckId);

                    if (truck is null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    client.ClientsTrucks.Add(new ClientTruck()
                    {
                        Client = client,
                        Truck = truck
                    });
                }

                clients.Add(client);
                sb.AppendLine(string.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
            }

            context.AddRange(clients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}