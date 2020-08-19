using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Model;

namespace ToDoList.Pages.TODO
{
    public class CreateToDoModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateToDoModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Todo Todo { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Todo.AddAsync(Todo);
                await _db.SaveChangesAsync();
                return RedirectToPage("TodoList");
            }
            else
            {
                return Page();
            }
        }
    }
}