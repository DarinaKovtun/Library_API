using LibraryAPI.Client;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeleteBookFromDBController : ControllerBase
    {
        private readonly IDynamoDBClient _dynamoDBClient;

        public DeleteBookFromDBController(IDynamoDBClient dynamoDBClient)
        {
            _dynamoDBClient = dynamoDBClient;
        }

        [HttpDelete(Name= "Delete Form DB")]
        public async Task<IActionResult> DeleteDataInDB(string ID, string Title)
        {
            var data = new DataForDB
            {
                ID = ID,
                Title = Title
            };
            var result = await _dynamoDBClient.DeleteBookFromDB(ID,Title);

            if (result == false)
            {
                return BadRequest("Cannot delete value in database. Please see console log");
            }
            return Ok("Value has been successfully deleted");
        }
    }
}
