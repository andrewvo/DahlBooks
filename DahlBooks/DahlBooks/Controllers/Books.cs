using Newtonsoft.Json;

namespace DahlBooks.Controllers
{
    public class Books
    {
        [JsonProperty("ids")]
        public int[] Ids { get; set; }
    }
}