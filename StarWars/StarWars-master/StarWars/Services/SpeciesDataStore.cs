using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StarWars.Models;
using Xamarin.Essentials;

namespace StarWars.Services
{
    public class SpeciesDataStore : IReadOnlyDataStore<Species>
    {
        HttpClient client;
        public List<Species> species { get; private set; }

        public SpeciesDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.StarWarsBaseUrl}");
            species = new List<Species>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public async Task<Species> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"species/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Species>(json));
            }

            return null;
        }

        public async Task<IEnumerable<Species>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"species");
                var response = await Task.Run(() => JsonConvert.DeserializeObject<APIResults<Species>>(json));

                species = response.results;
            }

            return species;
        }
    }
}