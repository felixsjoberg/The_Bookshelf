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

        public List<Books> books;
        public PropertyInfo[] propList;
        public Books NewBook = new Books(); //1.Everything in the create pizza comes here from the view

        public void OnGet()
        {
             propList = NewBook.GetType().GetProperties();

        }

        public IActionResult OnPost(Books NewBook)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //books.Add(NewBook);
            Services.JsonFileTaskService.SaveBook(NewBook); // this send the newbook onpost to JsonFiletaskservice method, which then writes to json-file
            return RedirectToAction("");
        }
    }

}

