using Microsoft.EntityFrameworkCore;
using Modul151.Todo.Api.Models;

namespace Modul151.Todo.Api.DataAccess
{

    public class TodoContext : DbContext
    {

        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
            
        }

        public DbSet<TodoItem> TodoItems {get; set;}

        public DbSet<User> Users { get; set; }
    }

}