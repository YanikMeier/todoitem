import { Injectable } from '@angular/core';
import { TodoItem } from "./todo-item-model";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class TodoItemService {
  formData: TodoItem
  readonly rootURL = 'https://localhost:5001/api'
  constructor(private http: HttpClient) { }


  //GET
  getTodoItem() {
    return this.http.get<any>(this.rootURL + '/TodoItem')
  }
  //Post
  postTodoItem(formData: TodoItem) {
    return this.http.post<any>(this.rootURL + '/TodoItem', formData)
  }
  
 
  
    
    // return this.http.delete<any>(this.rootURL + '/TodoItem/' + id)

  }

  




