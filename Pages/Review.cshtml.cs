using gruppArbete.Models;
using gruppArbete.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace gruppArbete.Pages
{
    public class ReviewModel : PageModel
    {
        private readonly ILogger<ReviewModel> _logger;
        public Books Book { get; set; }
        public List<Books> BookReview;
        public JsonFileTaskService BookService;
        public Books Review { get; set; }


        
        public ReviewModel(ILogger<ReviewModel>logger, JsonFileTaskService bookService)
        {
            _logger = logger;
            BookService = bookService;
        }
        public void OnGet(string id)
        {
            BookReview = BookService.GetTasks();
             Book = BookReview.FirstOrDefault(x => x.ISBN == id);
          
        }
        public void OnPost()
        {


            var review = Request.Form["review"];
            var isbn = Request.Form["isbn"];
            BookService.AddReviews(isbn, review);
            OnGet(isbn);

        }
    }
}
