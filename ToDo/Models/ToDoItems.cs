using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public class ToDoItems
    {
        public int ID { get; set; }
        public int ToDoListID { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public ToDoLists ToDoLists { get; set; }
    }
}