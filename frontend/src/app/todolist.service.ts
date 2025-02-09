import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../environments/environment.development';
import { ITask, ITaskResponse } from './models/task.models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TodolistService {

  constructor() { }
  private httpClient = inject(HttpClient)
  private baseURL = environment.baseURL + '/api/task'

  public getTasks(): Observable<ITaskResponse> {
    return this.httpClient.get<ITaskResponse>(this.baseURL)
  }

  public getTaskDetails(taskId: number): Observable<ITask> {
    return this.httpClient.get<ITask>(`${this.baseURL}/${taskId}`)
  }

  public createTask(task: ITask) {
    return this.httpClient.post(this.baseURL, task)
  }

  public editTask(task: ITask) {
    return this.httpClient.put(this.baseURL, task, {
      headers: { 'Content-Type': 'application/json' }
    })
  }

  public removeTask(taskId: number) {
    return this.httpClient.delete(`${this.baseURL}/${taskId}`)
  }
}
