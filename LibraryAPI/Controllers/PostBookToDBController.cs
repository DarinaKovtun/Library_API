using LibraryAPI.Client;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostBookToDBController : ControllerBase
    {
        private readonly IDynamoDBClient _dynamoDbClient;
        public PostBookToDBController(IDynamoDBClient dynamoDbClient)
        {
            _dynamoDbClient = dynamoDbClient;
        }
        [HttpPost (Name = "PostToDB")]
        public async Task<IActionResult> Add([FromBody] DataForDB dataForDB)
        {
            var data = new DataForDB
            {
                ID= dataForDB.ID,
                Title = dataForDB.Title
            };
            var result = await _dynamoDbClient.PostDataToDB(data);

            if (result == false)
            {
                return BadRequest("Cannot insert value in database. Please see console log");
            }
            return Ok("Value has been successfully added to DB");
        }

    }
}
