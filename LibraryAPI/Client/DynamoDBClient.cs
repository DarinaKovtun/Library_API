using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using LibraryAPI.Extension;
using LibraryAPI.Models;
using System.Text.RegularExpressions;

namespace LibraryAPI.Client
{
    public class DynamoDBClient : IDynamoDBClient
    {
        public string _tablename { get; set; }
        private readonly IAmazonDynamoDB _dynamoDB;
        public DynamoDBClient(IAmazonDynamoDB dynamoDB)
        {
            _dynamoDB = dynamoDB;
            _tablename = Constant.Constants.tablename;
        }
        public async Task<bool> PostDataToDB(DataForDB dataForDB)
        {
            var request = new PutItemRequest
            {
                TableName = _tablename,
                Item = new Dictionary<string, AttributeValue>
                 {
                     {"ID", new AttributeValue{S = dataForDB.ID} },
                    {"Title", new AttributeValue {S= dataForDB.Title } }
                 }
            };
            try
            {
                var response = await _dynamoDB.PutItemAsync(request);

                return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                Console.WriteLine("Here is your error \n" + e);
                return false;
            }
        }

        public async Task<bool> DeleteBookFromDB(string ID, string Title)
        {
            var request = new DeleteItemRequest
            {
                TableName = _tablename,
                Key = new Dictionary<string, AttributeValue>()
                {
                 
                     {"ID", new AttributeValue{S = ID} },
                     {"Title", new AttributeValue{S = Title} }
                }
            };

            try
            {
                var response = await _dynamoDB.DeleteItemAsync(request);

                return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                Console.WriteLine("Here is your error \n" + e);
                return false;
            }
        }

    }
    
}
