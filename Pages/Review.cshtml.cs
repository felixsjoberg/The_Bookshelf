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
        


        
        public ReviewModel(ILogger<ReviewModel>logger, JsonFileTaskService bookService)
        {
            _logger = logger;
            BookService = bookService;
        }
        public void OnGet(string id)
        {
            //var noblePrice = Book.NobelPriceWinner;
            //if (noblePrice == true)
            //{
                
            //}
            BookReview = BookService.GetTasks();

            // a mini loop to read the list of books and search for ISBN as an ID
            Book = BookReview.FirstOrDefault(x => x.ISBN == id );
            if(Book.Review == null)
            {
                // replace null value with "No Reviews Yet .."
                Book.Review = new string[] { "No Reviews Yet ..." };      
            }
           
        }
        public void OnPost()
        {
            //Guiding the program to find where changes will be made in JSON file
            var review = Request.Form["review"];                         
            var isbn = Request.Form["isbn"];
            BookService.AddReviews(isbn, review );                          
            OnGet(isbn);
            
        }
        
    }
}
