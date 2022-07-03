using LibraryAPI.Models;
namespace LibraryAPI.Client
{
    public interface IDynamoDBClient
    {
        public Task<bool> PostDataToDB(DataForDB dataForDB);
        public Task<bool> DeleteBookFromDB(string ID, string Title);
    }
}
