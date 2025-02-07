import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TodolistService } from './todolist.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  todoList = inject(TodolistService)
}
