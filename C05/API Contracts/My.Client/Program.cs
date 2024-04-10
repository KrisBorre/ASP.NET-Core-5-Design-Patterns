using My.Api.Contracts;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace My.Client
{
    public class Program
    {
        private static readonly HttpClient _http = new HttpClient();

        private static async Task Main(string[] args)
        {
            var uri = "https://localhost:5002/api/clients";

            // Read all summaries
            WriteTitle("All clients summaries");
            var clients = await FetchAndWriteFormattedJsonAsync<ClientSummaryDto[]>(uri);

            // Read all details
            foreach (var summary in clients)
            {
                WriteTitle($"Details of {summary.Name} (id: {summary.Id})");
                await FetchAndWriteFormattedJsonAsync<ClientDetailsDto>($"{uri}/{summary.Id}");
            }

            Console.ReadLine();
        }

        private static async Task<TContract> FetchAndWriteFormattedJsonAsync<TContract>(string uri)
        {
            var response = await _http.GetStringAsync(uri);
            var deserializedObject = JsonSerializer.Deserialize<TContract>(response);
            var formattedJson = JsonSerializer.Serialize(deserializedObject, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(formattedJson);
            return deserializedObject;
        }

        private static void WriteTitle(string title)
        {
            var initialColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine(title);
            Console.ForegroundColor = initialColor;
        }
    }
}
