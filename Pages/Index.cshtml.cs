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
        public JsonFileTaskService TaskService;
        public IEnumerable<Task> Tasks { get; private set; }

        public IndexModel(ILogger<IndexModel> logger,
            JsonFileTaskService taskService)
        {
            _logger = logger;
            TaskService = taskService;
        }

        public void OnGet()
        {

            Tasks = TaskService.GetTasks();

        }
    }
}

