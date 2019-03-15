import { Component, OnInit } from '@angular/core';
import { TodoItemService } from '../shared/todo-item.service';
import { NgForm } from '@angular/forms'
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private todoitemservice: TodoItemService, private http: HttpClient) { }

  todoitem: any[]

  ngOnInit() {
    this.resetForm();
    this.getItems();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();
    this.todoitemservice.formData = {
      Id: 0,
      Name: '',
      Date: null,
      Message: '',
      Importance: ''
    }
  }

  getItems() {
    this.todoitemservice.getTodoItem().subscribe((data) =>
      this.todoitem = data);
  }

  onSubmit() {
    this.todoitemservice.postTodoItem(this.todoitemservice.formData).subscribe(
      res => {
        console.log(res);
        this.getItems();
      },
      err => {
        console.log(err);
      }
    );
    this.resetForm();
  }

  deleteItem(id) {
    return this.http.delete<any>('https://localhost:5001/api/TodoItem/' + id).subscribe(
      res => {
        console.log(res)
        this.getItems();
      },
      err => {
        console.log("Error" + err);
      }
    )
  }

  delete(id) {
    this.deleteItem(id)
    // return this.http.delete<any>(this.rootURL + '/TodoItem/' + id)

  }

}
