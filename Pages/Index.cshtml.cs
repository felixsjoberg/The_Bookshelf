using System;
using System.Collections.Generic;
using System.Linq;
using gruppArbete.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using gruppArbete.Models;

namespace gruppArbete.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileTaskService BooksService; //object of services, to be able to use method gettasks().
        public List<Books> books { get; set; }

        public IndexModel(ILogger<IndexModel> logger,
            JsonFileTaskService taskService)
        {
            _logger = logger;
            BooksService = taskService;
        }

        public void OnGet()
        {

            books = BooksService.GetTasks();

        }
        public string HaveRead(Books book)
        {
            return book.Read ? "Yes" : "No";
        }
    }
}

