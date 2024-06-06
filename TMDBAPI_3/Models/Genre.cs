using Newtonsoft.Json;

namespace TMDBAPI_3.Models
{
    public class Genre
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }

    public class GenreResponse
    {
        [JsonProperty("genres")]
        public List<Genre>? Genres { get; set; }
    }

}
