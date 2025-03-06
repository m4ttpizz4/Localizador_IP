using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

class Program
{
    static async Task Main()
    {
        Console.Write("Digite o endereço IP: ");
        string ip = Console.ReadLine();
        
        string url = $"http://ip-api.com/json/{ip}";
        
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                JObject data = JObject.Parse(jsonResponse);
                
                Console.WriteLine("\nInformações do IP:");
                Console.WriteLine($"País: {data["country"]}");
                Console.WriteLine($"Região: {data["regionName"]}");
                Console.WriteLine($"Cidade: {data["city"]}");
                Console.WriteLine($"Latitude: {data["lat"]}");
                Console.WriteLine($"Longitude: {data["lon"]}");
                Console.WriteLine($"ISP: {data["isp"]}");
            }
            else
            {
                Console.WriteLine("Erro ao obter informações do IP.");
            }
        }
    }
}