import { Component, inject, Input, numberAttribute, OnInit } from '@angular/core';
import { TodolistService } from '../todolist.service';
import { ITask } from '../models/task.models';
import { TaskFormComponent } from "../task-form/task-form.component";
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-task',
  imports: [TaskFormComponent],
  templateUrl: './edit-task.component.html',
  styleUrl: './edit-task.component.css'
})
export class EditTaskComponent implements OnInit {
  @Input({transform: numberAttribute})
  taskId!: number

  todoListService = inject(TodolistService)
  router = inject(Router)
  taskModel?: ITask
  
  ngOnInit(): void {
    this.todoListService.getTaskDetails(this.taskId).subscribe(task => {
      task.dueDate = new Date(task.dueDate).toISOString()
      this.taskModel = task
    })
  }

  saveChanges(task: ITask) {
    if (task.title.trim() && task.description.trim() && task.dueDate.toString().trim()) {
      this.todoListService.editTask(task).subscribe({
        next: () => this.router.navigate(['']),
        error: error => console.log('Request Failed:', error)
      })
    }
  }
}
