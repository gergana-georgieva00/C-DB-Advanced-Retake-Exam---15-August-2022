﻿namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
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
            throw new NotImplementedException();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            var clientDtos = JsonConvert.DeserializeObject<ImportJsonClient[]>(jsonString);

            var clients = new List<Client>();
            var clientsTrucks = new List<ClientTruck>();


        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}