using MVC_AJAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC_AJAX.Controllers
{
    [Route("api/todo")]
    public class TodoApiController : ApiController
    {
        static TodoApiController()
        {
            var id = Guid.NewGuid();
            TodoListDb = new Dictionary<Guid, TodoListItem>{
                { id, new TodoListItem { Id = id, Title = "Selvangivelse" } }
            };
        }
        private static Dictionary<Guid, TodoListItem> TodoListDb;

        // GET: api/todo
        public IEnumerable<TodoListItem> Get()
        {
            return TodoListDb.Values; 
        }

        // GET: api/todo/5
        [Route("api/todo/{id}")]
        public TodoListItem Get(Guid id)
        {
            return TodoListDb[id];
        }

        // POST: api/todo
        public TodoListItem Post([FromBody]TodoListItem item)
        {
            item.Id = Guid.NewGuid();
            TodoListDb.Add(item.Id, item);

            return item;
        }

        // PUT: api/todo/5
        [Route("api/todo/{id}")]
        public TodoListItem Put(Guid id, [FromBody]TodoListItem item)
        {
            if (!TodoListDb.Keys.Contains(id))
                throw new ArgumentException("Todo item not found", "id");
            throw new Exception();
            TodoListDb[id] = item;

            return item;
        }

        // DELETE: api/todo/5
        [Route("api/todo/{id}")]
        public void Delete(Guid id)
        {
            TodoListDb.Remove(id);
        }
    }
}
