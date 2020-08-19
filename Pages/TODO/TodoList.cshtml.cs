using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoList.Model;

namespace ToDoList.Pages.TODO
{
    public class TodoListModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public TodoListModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Todo> Todos { get; set; }

        public async Task OnGet()
        {
            Todos = await _db.Todo.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var task = await _db.Todo.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            _db.Todo.Remove(task);
            await _db.SaveChangesAsync();

            return RedirectToPage("TodoList");
        }
    }
}