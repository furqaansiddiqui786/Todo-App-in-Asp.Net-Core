using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Model
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TodoName { get; set; }

        public string Tododesc { get; set; }
    }
}
