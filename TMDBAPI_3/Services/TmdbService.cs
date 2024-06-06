using Newtonsoft.Json;
using TMDBAPI_3.Models;

namespace TMDBAPI_3.Services
{
    public class TmdbService
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiKey = "512747022d099ad077bc7dee75982174";

        // definir o construtor da classe
        public TmdbService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // action - métodos - Funções
        // async - sinaliza para que o programa continue a trabalhar sem ficar esperando a resposta do chamado do método
        public async Task<List<Genre>> GetGenreAsync()
        {
            // Cria a variável response que consultará o domínio da api 
            var response = await _httpClient.GetStringAsync($"https://api.the.moviedb.org/3/genre/movie/list?api_key={_apiKey}&language=pt-BR");

            // cria a variável genres que receberá os dados do Json que é 
            // retornando pela consulta a api
            var genres = JsonConvert.DeserializeObject<GenreResponse>(response);
            return genres.Genres;
        }
        public async Task<List<Movie>> SearchMoviesAsync(string query, int? genreId, int? year)
        {
            // executa a consulta ao endpoint da url e retorna o valor 
            var url = $"https://api.themoviedb.org/3/search/movie?api_key={_apiKey}&language=pt-BR&query={query}";

            // se existir o valor de genreId, acrescente a referencia na url
            if (genreId.HasValue)
                url += $"genres={genreId.Value}";

            // se existir o valor de year, acrescente a referencia na url
            if (year.HasValue)
                url += $"&year={year.Value}";

            var response = await _httpClient.GetStringAsync(url);
            var movies = JsonConvert.DeserializeObject<MovieResponse>(response);

            return movies.Results;
        }

    }
}
