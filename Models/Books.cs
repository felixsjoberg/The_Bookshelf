using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace gruppArbete.Models
{
    [Serializable]
    public class Books
    {
        [BindProperty]
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }

        public string ReleaseDate { get; set; }
        public bool Read { get; set; }
        public int Price { get; set; }

        public bool NobelPriceWinner { get; set; }
        public bool Ownership { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Image { get; set; }
        public string[] Review { get; set; }

    }


}

