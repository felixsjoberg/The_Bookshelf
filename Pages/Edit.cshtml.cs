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

            //if (ModelState.IsValid == false) // make sure fields that are req is filled.
            //{
            //    TempData["error"] = "Error while creating book";

            //    return Page();
            //}
            //var author = Request.Form["review"];
            //var isbn = Request.Form["isbn"];
            //var genre = Request.Form["review"];
            //var language = Request.Form["isbn"];
            //var releasedate = Request.Form["review"];
            //var read = Request.Form["isbn"];
            //var price = Request.Form["isbn"];
            //var nobelpricewinner = Request.Form["isbn"];
            //var ownership = Request.Form["isbn"];
            //var publisher = Request.Form["isbn"];
            //var image = Request.Form["isbn"];
            BooksService.Edit(Books);
            TempData["success"] = "Book updated successfully";
            return RedirectToAction("./Index");
        }
    }

}

