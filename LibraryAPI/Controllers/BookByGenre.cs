using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Models;
using LibraryAPI.Client;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookByGenre : ControllerBase
    {
        [HttpGet(Name = "Books by Genre")]
        public async Task<BookChoose[]> GetBooks(string genre)
        {
            LibraryClient client = new LibraryClient();
            return client.GetBookChooseByGenre(genre).Result;
        }

    }
}
