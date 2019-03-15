using System;
using System.Collections.Generic;

namespace Modul151.Todo.Api.Models

{
 public class User
 {
     public long ID { get; set; }
     public string Name { get; set; }
     public string Email {  get; set; }
     public byte[] PwHash { get; set; }
     public IEnumerable<TodoItem> TodoItems { get; set; }    
 }
}