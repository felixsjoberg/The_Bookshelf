
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

            public IWebHostEnvironment WebHostEnvironment { get; } // until here and above is just getting the website information

            private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "Data", "DataSourceInJson.json"); //Combining the website and the json file

        public IEnumerable<Books> GetTasks()
            {
                using var jsonFileReader = File.OpenText(JsonFileName);
                return JsonSerializer.Deserialize<Books[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }




