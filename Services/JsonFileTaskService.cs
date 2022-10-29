
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using gruppArbete.Models; // använd din namespace
    using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

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

             public List<Books>  GetTasks()
                {
                using var jsonFileReader = File.OpenText(JsonFileName);
                return JsonSerializer.Deserialize<List<Books>>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }

        //public static void SaveBook(List<Books> UpdateList)
        public static void SaveBook(List<Books> UpdateList)
        {
            string strResultJson = JsonConvert.SerializeObject(UpdateList);
            System.Console.WriteLine(strResultJson);
            /* temporary json file, the one we should use below */
            File.WriteAllText(@"test.json", strResultJson);

            /* This one write over everything in the JSON file. */
            //File.WriteAllText(@"wwwroot/Data/DataSourceInJson.json", strResultJson); 

        }

    }
    }




