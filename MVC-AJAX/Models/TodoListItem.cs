using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AJAX.Models
{
    public class TodoListItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}