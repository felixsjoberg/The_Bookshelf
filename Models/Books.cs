using System;
using Newtonsoft.Json;
using System.Text.Json;


namespace gruppArbete.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class Books
    {
        public string Title { get; set; }
        public string Author { get; set; }

        [JsonProperty("ISBN Nr")]
        public string ISBNNr { get; set; }
        public string Subject { get; set; }
        public string Language { get; set; }

        [JsonProperty("Release Date")]
        public object ReleaseDate { get; set; }
        public bool Read { get; set; }
        public int Price { get; set; }
        public string publisher { get; set; }
        public string Type { get; set; }

        [JsonProperty("Nobel Price Winner")]
        public bool NobelPriceWinner { get; set; }
        public bool Ownership { get; set; }
        //public string Publisher { get; set; }
    }


}

