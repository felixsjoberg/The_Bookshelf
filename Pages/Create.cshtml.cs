using System;
using System.Collections.Generic;
using System.Linq;
using gruppArbete.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using gruppArbete.Models;
using System.Reflection;

namespace gruppArbete.Pages
{
    public class CreateModel : PageModel
    {
        
        [BindProperty]
        public List<Books> Books { get; set; }

        public PropertyInfo[] propList;//list with all the different properties from services (list<books>)
        public Books BookProperties = new Books(); //1.Everything in the create  comes here from the view
        public JsonFileTaskService BooksService; //object of services
        private readonly ILogger<IndexModel> _logger;

        public CreateModel(ILogger<IndexModel> logger,
            JsonFileTaskService taskService)
        {
            _logger = logger;
            BooksService = taskService;
        }

        public void OnGet()
        {
             propList = BookProperties.GetType().GetProperties();
            Books = BooksService.GetTasks();
            Books = new List<Books> {
                new Books{  Title="", Author="", ISBN="",Genre="",Language="",ReleaseDate="",
                Read=false,Price=0,Publisher="",NobelPriceWinner=false,Ownership=false,Image=""}
                
            };


        }

        // Below code is a work in progress..
        public IActionResult OnPost()
        {

            if (ModelState.IsValid == false) // make sure fields that are req is filled.
            {
                TempData["error"] = "Error while creating book";

                return Page();
            }
            for (int i = 0; i < Books.Count; i++)
            {
                Console.WriteLine(Books[i]);
            }
            Console.WriteLine(Books[0].Title);
            Console.WriteLine(Books[0].Author);

            //var emailAddress = Request.Form["emailaddress"];
            //List<Books> UpdatedList = Books;
            //UpdateList.Add(NewBook);
            // save code below when implementing the function, but i'll first make sure I'm able to write all properties to JSON-data.
            //books.Add(NewBook);
            Services.JsonFileTaskService.SaveBook(Books); // this send the newbook onpost to JsonFiletaskservice method, which then writes to json-file
            TempData["success"] = "Book created successfully";
            return RedirectToAction("./Index");
        }
    }

}

