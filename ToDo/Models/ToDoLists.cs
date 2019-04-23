using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public class ToDoLists
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }

        public ICollection<ToDoItems> ToDoItems { get; set; }
    }
}
