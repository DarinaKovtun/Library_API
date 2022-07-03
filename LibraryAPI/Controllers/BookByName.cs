using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Models;
using LibraryAPI.Client;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookByName : ControllerBase
    {

        [HttpGet(Name = "Books by Name")]
        public async Task<IEnumerable<Book>> GetBooks(string name)
        {
            LibraryClient client = new LibraryClient();
            return client.GetBookChooseByName(name).Result;

        }
       
    }

}
