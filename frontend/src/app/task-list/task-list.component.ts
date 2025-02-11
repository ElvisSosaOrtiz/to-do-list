import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { TodolistService } from '../todolist.service';
import { ITask } from '../models/task.models';
import {MatTableModule} from '@angular/material/table';
import {MatCheckboxChange, MatCheckboxModule} from '@angular/material/checkbox';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';

@Component({
  selector: 'app-task-list',
  imports: [RouterLink, MatTableModule, MatCheckboxModule, MatButtonModule, MatIconModule],
  templateUrl: './task-list.component.html',
  styleUrl: './task-list.component.css'
})
export class TaskListComponent {
  todoListService = inject(TodolistService)
  tasks: ITask[] = []
  displayedColumns: string[] = ['title', 'description', 'dueDate', 'isCompleted', 'actions'];

  constructor() {
    this.loadList()
  }

  loadList() {
    this.todoListService.getTasks().subscribe(task => {
      this.tasks = task.tasks.map(t => {
        t.dueDate = new Date(t.dueDate).toLocaleDateString()
        return t
      })
    })
  }

  removeTask(taskId: number) {
    this.todoListService.removeTask(taskId).subscribe({
      next: () => this.loadList(),
      error: error => console.log('Remove task failed', error)
    })
  }

  setTaskCompleted(task: ITask, event: MatCheckboxChange) {
    task.isCompleted = event.checked
    task.dueDate = new Date(task.dueDate).toISOString()
    this.todoListService.editTask(task).subscribe({
      next: () => this.loadList(),
      error: error => console.error('Update failed', error)
    })
  }
}
