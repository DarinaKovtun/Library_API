using LibraryAPI.Models;
using Newtonsoft.Json;
using LibraryAPI.Constant;

namespace LibraryAPI.Client
{
    public class LibraryClient
    {
        private HttpClient _httpClient;
        private string _address;
        private string _apikey;

        public LibraryClient()
        {
            _address = Constants.address;
            _apikey = Constants.apikey;
            _httpClient = new HttpClient();
        }

        public async Task<Book[]> GetBookChooseByName(string title)
        {
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://hapi-books.p.rapidapi.com/search/" + title),
                    Headers =
    {
        { "X-RapidAPI-Key", "9d79daf326msh74ee25a2b474bbdp14ffebjsna97efddef472" },
        { "X-RapidAPI-Host", "hapi-books.p.rapidapi.com" },
    },
                };

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Book[]>(body);
            }

        }
        public async Task<BookChoose> GetBookChooseByID(int id)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://hapi-books.p.rapidapi.com/book/" + id),
                Headers =
    {
        { "X-RapidAPI-Key", "9d79daf326msh74ee25a2b474bbdp14ffebjsna97efddef472" },
        { "X-RapidAPI-Host", "hapi-books.p.rapidapi.com" },
    },
            };
            BookChoose bookchoose = new BookChoose();
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                bookchoose = JsonConvert.DeserializeObject<BookChoose>(body);
            }
            return bookchoose;
        }

        public async Task<BookChoose[]> GetBookChooseByGenre(string genre)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://hapi-books.p.rapidapi.com/week/" + genre),
                Headers =
    {
        { "X-RapidAPI-Key", "9d79daf326msh74ee25a2b474bbdp14ffebjsna97efddef472" },
        { "X-RapidAPI-Host", "hapi-books.p.rapidapi.com" },
    },
            };

            using var response = await _httpClient.SendAsync(request);
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BookChoose[]>(body);
            }

        }
    }
}


