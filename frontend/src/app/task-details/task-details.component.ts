import { Component, inject, Input, numberAttribute, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { TodolistService } from '../todolist.service';
import { ITask } from '../models/task.models';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatCheckboxChange, MatCheckboxModule } from '@angular/material/checkbox';

@Component({
  selector: 'app-task-details',
  imports: [RouterLink, MatButtonModule, MatIconModule, MatCheckboxModule],
  templateUrl: './task-details.component.html',
  styleUrl: './task-details.component.css'
})
export class TaskDetailsComponent implements OnInit {
  todoListService = inject(TodolistService)
  taskModel!: ITask

  @Input({transform: numberAttribute})
  taskId!: number
  
  ngOnInit(): void {
    this.todoListService.getTaskDetails(this.taskId).subscribe(task => {
      this.taskModel = task
    })
  }

  setTaskCompleted(event: MatCheckboxChange) {
    this.taskModel.isCompleted = event.checked
    this.taskModel.dueDate = new Date(this.taskModel.dueDate).toISOString()
    this.todoListService.editTask(this.taskModel).subscribe({
      error: error => console.error('Update failed', error)
    })
    this.taskModel.dueDate = new Date(this.taskModel.dueDate).toLocaleDateString()
  }

  deleteTask() {
    this.todoListService.removeTask(this.taskId).subscribe({
      error: error => console.log("Delete Failed", error)
    })
  }
}
