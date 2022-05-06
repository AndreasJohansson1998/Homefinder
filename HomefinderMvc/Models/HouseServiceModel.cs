using HomefinderMvc.ViewModels;
using System.Text.Json;

namespace HomefinderMvc.Models
{
    public class HouseServiceModel
    {
        private readonly string _baseUrl;
        private readonly JsonSerializerOptions _options;
        private readonly IConfiguration _config;

        public HouseServiceModel(IConfiguration config)
        {
            _config = config;
            _baseUrl = $"{_config.GetValue<string>("baseUrl")}/houses";

            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<HouseViewModel>> ListAllHouses()
        {
            var url = $"{_baseUrl}";

            using var http = new HttpClient();
            var response = await http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Det gick inget vidare");
            }

            var houses = await response.Content.ReadFromJsonAsync<List<HouseViewModel>>();
            // var result = await response.Content.ReadAsStringAsync();
            // var vehicles = JsonSerializer.Deserialize<List<HouseViewModel>>(result, _options);

            return houses ?? new List<HouseViewModel>();
        }
    }
}