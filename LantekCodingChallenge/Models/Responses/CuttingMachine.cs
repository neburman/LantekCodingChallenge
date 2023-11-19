using Newtonsoft.Json;

namespace LantekCodingChallenge.Models.Responses
{
    public class CuttingMachine
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "manufacturer")]
        public string Manufacturer { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "technology")]
        public string CuttingTechnology { get; set; } = string.Empty;


    }
}
