using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Model;

namespace ToDoList.Pages.TODO
{
    public class EditTodoModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditTodoModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Todo Todo { get; set; }

        public async Task OnGet(int id)
        {
            Todo = await _db.Todo.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var todo = await _db.Todo.FindAsync(Todo.Id);
                todo.TodoName = Todo.TodoName;
                todo.Tododesc = Todo.Tododesc;

                await _db.SaveChangesAsync();
                return RedirectToPage("TodoList");
            }
            return RedirectToPage();
        }
    }
}