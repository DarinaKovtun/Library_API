using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Models;
using LibraryAPI.Client;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookByID : ControllerBase
    {
        [HttpGet(Name = "Get Books By Id")]
        public async Task<BookChoose> GetBooks(int id)
        {
            LibraryClient client = new LibraryClient();
            return client.GetBookChooseByID(id).Result;
        }

    }
}
