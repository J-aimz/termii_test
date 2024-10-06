using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using Termii.Core.Clients.Termii;
using Termii.Core.Models.Configurations;
using Termii.Core.Models.Services.Foundations.Termii.Switch;


namespace TermiiTest.Api
{
    public class TermiiMessagingService : ITermiiMessagingService
    {
        private static readonly string _apiKey = "TLSdcNilEUUaBZILwOSnooyWGMyDhVJBgLbixtVIQNcuBqXslQfXTCNLpbKzzX";


        public async Task SendMessage()
        {
            ApiConfigurations apiConfig = new ApiConfigurations()
            {
                ApiKey = _apiKey,
            };


            var termiiClient = new TermiiClient(apiConfig);

            var contacts = new List<string>() 
            {
                "2347034659952",
                "2348181532718",
                "23481325716619"
            };


            SendBulkMessage sendBulkMessageRequest = new();

            sendBulkMessageRequest.Request = new SendBulkMessageRequest()
            {
                To = contacts,
                From = "Lengoal.co",
                Sms = "Welcome to lengoal from termii.",
                Type = "plain",
                Channel = "generic",
                ApiKey = _apiKey,
            };

            try
            {

                var retrievedTermiiModel =
                  await termiiClient.Switch.SendBulkMessagesAsync(sendBulkMessageRequest);
                Console.WriteLine(retrievedTermiiModel);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {err}", ex);
                throw new Exception("err: {err}", ex);
            }
          

            //return retrievedTermiiModel;

        }


    }
}
