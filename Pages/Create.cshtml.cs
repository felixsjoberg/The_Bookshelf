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
        public Books Books { get; set; }

        public List<Books> books;
        public PropertyInfo[] propList;//list with all the different properties from services (list<books>)
        public Books NewBook = new Books(); //1.Everything in the create  comes here from the view
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
             propList = NewBook.GetType().GetProperties();
            books = BooksService.GetTasks();


        }

        // Below code is a work in progress..
        public IActionResult OnPost(Books NewBook)
        {
            if (ModelState.IsValid == false) // make sure fields that are req is filled.
            {
                return Page();
            }
            var emailAddress = Request.Form["emailaddress"];

            // save code below when implementing the function, but i'll first make sure I'm able to write all properties to JSON-data.
            //books.Add(NewBook);
            //Services.JsonFileTaskService.SaveBook(books); // this send the newbook onpost to JsonFiletaskservice method, which then writes to json-file
            return RedirectToAction("./Index");
        }
    }

}

