using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modul151.Todo.Api.Models;
using Modul151.Todo.Api.DataAccess;

namespace Csbe.Todo.Api.Controllers
{
    [Route("api/User")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly TodoContext _todoContext;

        public UserController(TodoContext context)
        {
            _todoContext = context;


            if (_todoContext.Users.Count() == 0)
            {
                _todoContext.Users.Add(new User
                {
                    Name = "Task",
                    Email = "yanik.meier44@gmail.com"
                });
                _todoContext.SaveChanges();
            }
        }


        //GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> ReadAllTodoItems()
        {
            return await _todoContext.Users.ToListAsync();
        }
        //GET: api/user/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> ReadTodoItemById(long id)
        {
            var user = await _todoContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();

            }

            return user;
        }

        //POST: api/user
        [HttpPost]
        public async Task<ActionResult<User>> CreateTodoItem(User user)
        {
            _todoContext.Users.Add(user);
            await _todoContext.SaveChangesAsync();
            return CreatedAtAction("ReadTodoItemById", new { id = user.ID }, user);
        }

        //PUT: api/user{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(long id, User user)
        {
            if (id != user.ID)
            {
                return BadRequest();
            }

            _todoContext.Entry(user).State = EntityState.Modified;
            try
            {
                await _todoContext.SaveChangesAsync(); // can throw an exception if there is no item
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            return NoContent();
        }

        //DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(long id)
        {
            var user = await _todoContext.Users.FindAsync(id);
            if (user == null) return BadRequest();

            _todoContext.Users.Remove(user);
            await _todoContext.SaveChangesAsync();

            return NoContent();
        }
    }
}