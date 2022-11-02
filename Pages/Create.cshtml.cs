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
        public List<Books> books { get; set; }

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
            books = BooksService.GetTasks();

        }

        public IActionResult OnPost()
        {
            books = BooksService.GetTasks();

            if (ModelState.IsValid == false) // make sure fields that are req is filled.
            {
                TempData["error"] = "Error while creating book";

                return Page();
            }
            books.Add(Books);
            
            Services.JsonFileTaskService.SaveBook(books); // this sends the update list onpost to JsonFiletaskservice method, which then writes to json-file
            TempData["success"] = "Book created successfully";
            return RedirectToAction("./Index");
        }
    }

}

