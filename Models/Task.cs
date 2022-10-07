using System;
using System.Text.Json;

namespace gruppArbete.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string description { get; set; }
        public string created_at { get; set; }
        public bool is_complete { get; set; }

        public override string ToString() =>
            JsonSerializer.Serialize<Task>(this); // Convert the c# data to JSON    
    }

}

