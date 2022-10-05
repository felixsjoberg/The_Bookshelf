
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using gruppArbete.Models; // använd din namespace
    using Microsoft.AspNetCore.Hosting;

    namespace gruppArbete.Services
    {
        public class JsonFileTaskService
        {
            public JsonFileTaskService(IWebHostEnvironment webHostEnvironment)
            {
                WebHostEnvironment = webHostEnvironment;
            }

            public IWebHostEnvironment WebHostEnvironment { get; }

            private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Task.json");

            public IEnumerable<Task> GetTasks()
            {
                using var jsonFileReader = File.OpenText(JsonFileName);
                return JsonSerializer.Deserialize<Task[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }




