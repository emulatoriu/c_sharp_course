using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncFunctionAndWPF
{
    public class StarWarsApiClient
    {
        private readonly HttpClient httpClient;

        public StarWarsApiClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://swapi.dev/api/");
        }

        public async Task<Planet> GetPlanetAsync(int planetId)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"planets/{planetId}/");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            Planet planet = JsonConvert.DeserializeObject<Planet>(json);

            return planet;
        }
    }

}