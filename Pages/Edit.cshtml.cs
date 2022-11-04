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
    public class EditModel : PageModel
    {

        [BindProperty] 
        public Books Books { get; set; }
        public List<Books> books { get; set; }

        public JsonFileTaskService BooksService; //object of services
        private readonly ILogger<IndexModel> _logger;

        public EditModel(ILogger<IndexModel> logger,
            JsonFileTaskService taskService)
        {
            _logger = logger;
            BooksService = taskService;
        }

        public void OnGet(string id)
        {
            books = BooksService.GetTasks();
            Books = books.FirstOrDefault(x => x.ISBN == id);

        }

        public IActionResult OnPost()
        {

            BooksService.Edit(Books);
            if (Books.Title == null)
            {
                TempData["note"] = "Book deleted successfully";
            }
            else
            {
                TempData["success"] = "Book updated successfully";
            }
            return RedirectToAction("./Index");
        }

    }

}

