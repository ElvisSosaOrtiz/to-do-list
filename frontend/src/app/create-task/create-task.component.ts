import { Component, inject } from '@angular/core';
import { TaskFormComponent } from "../task-form/task-form.component";
import { TodolistService } from '../todolist.service';
import { Router } from '@angular/router';
import { ITask } from '../models/task.models';

@Component({
  selector: 'app-create-task',
  imports: [TaskFormComponent],
  templateUrl: './create-task.component.html',
  styleUrl: './create-task.component.css'
})
export class CreateTaskComponent {
  router = inject(Router)
  todoListService = inject(TodolistService)

  saveChanges(task: ITask) {
    if (task.title.trim() && task.description.trim() && task.dueDate.toString().trim()) {
      this.todoListService.createTask(task).subscribe({
        next: () => this.router.navigate(['']),
        error: error => console.log('Request Failed:', error)
      })
    }
  }
}
