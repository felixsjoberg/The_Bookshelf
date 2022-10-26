using System;

using System.Text.Json;


namespace gruppArbete.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class Books
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public string ISBN { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }

        public int ReleaseDate { get; set; }
        public bool Read { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }

        public bool NobelPriceWinner { get; set; }
        public bool Ownership { get; set; }
        public string Publisher { get; set; }

        public string Image { get; set; }
    }


}

