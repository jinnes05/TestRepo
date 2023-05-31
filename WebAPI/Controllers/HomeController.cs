using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        private CosmosClient cosmosClient;
        private Database db;
        private Container dbc1;

        public HomeController()
        {
            //cosmosClient = new CosmosClient("AccountEndpoint=https://jjiexampractice-cdba.documents.azure.com:443/;AccountKey=p8Seqeb5QnsarA5rIgCKnUDFCfxy9xeRWsiEiWQqYo7lAvysLhalDl3E172hdip68gAIhxdrN3PYACDbiwMO8w==;");
            //db = cosmosClient.CreateDatabaseIfNotExistsAsync("exampractice-db").Result.Database;
            //dbc1 = db.CreateContainerIfNotExistsAsync(new ContainerProperties("exampractice-dbc1", "/category"), ThroughputProperties.CreateAutoscaleThroughput(1000)).Result.Container;
        }

        [HttpGet("")]
        public string get()
        {
            return "This is the API, try calling it:" +
                Environment.NewLine + "  'HelloWorld' gives you a greeting and a timestamp" +
                Environment.NewLine + "  'LongOperation' gives you a test for a long running function";
        }
        [HttpGet("HelloWorld")]
        public string HelloWorld()
        {
            return "Hello World!!!" + Environment.NewLine + Environment.NewLine + "This was retrieved via API call at " + DateTime.Now.ToString() + ".";
        }

        [HttpGet("LongOperation")]
        public string LongOperation()
        {
            DateTime startTime = DateTime.Now;
            Random random= new Random();
            Thread.Sleep(random.Next(1000, 4000));
            return "This operation started at " + startTime.ToString() + " and ended at " + DateTime.Now + ".";
        }

        //[HttpPost("AddNote")]
        //public async Task AddNote(string title, string body, string category = "uncategorised")
        //{
        //    await dbc1.CreateItemAsync<Note>(new Note
        //    {
        //        id = title,
        //        Title = title,
        //        Body = body,
        //        category = category
        //    });
        //}

        //[HttpGet("GetNotes")]
        //public async Task<List<Note>> GetNotes()
        //{
        //    List<Note> notes = new List<Note>();
        //    FeedIterator<Note> i = dbc1.GetItemQueryIterator<Note>(new QueryDefinition("SELECT * FROM c"));
        //    while (i.HasMoreResults)
        //    {
        //        notes.AddRange(await i.ReadNextAsync());
        //    }

        //    return notes;
        //}
    }
}