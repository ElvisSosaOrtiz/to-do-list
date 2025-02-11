import { TestBed } from '@angular/core/testing';
import { HttpTestingController, HttpClientTestingModule  } from '@angular/common/http/testing'
import { TodolistService } from './todolist.service';
import { environment } from '../environments/environment.development';
import { ITaskResponse } from './models/task.models';

describe('TodolistService', () => {
  let service: TodolistService;
  let testingController: HttpTestingController

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(TodolistService);
    testingController = TestBed.inject(HttpTestingController)
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get all tasks', () => {
    service.getTasks().subscribe(taskResponse => {
      expect(taskResponse).toBeTruthy()
      expect(taskResponse.tasks.length).toBe(2)
      const secondTask = taskResponse.tasks.find(task => task.taskId === 2)
      expect(secondTask!.title).toBe('Test 2')
    })
    const mockRequest = testingController.expectOne(environment.baseURL + '/api/task')
    expect(mockRequest.request.method).toEqual('GET')
    const taskResponse: ITaskResponse = {
      tasks: [
        {
          taskId: 1,
          title: 'Test',
          description: 'Test',
          dueDate: new Date('02/02/2025').toISOString(),
          isCompleted: false
        },
        {
          taskId: 2,
          title: 'Test 2',
          description: 'Test 2',
          dueDate: new Date('02/03/2025').toISOString(),
          isCompleted: false
        }
      ]
    }
    mockRequest.flush(taskResponse)
  })

  it('should retrieve one task', () => {
    service.getTaskDetails(1).subscribe(task => {
      expect(task).toBeTruthy()
      expect(task.title = 'Test')
    })
    const mockRequest = testingController.expectOne(environment.baseURL + '/api/task/1')
    expect(mockRequest.request.method).toEqual('GET')
    const task = {
      taskId: 1,
      title: 'Test',
      description: 'Test',
      dueDate: new Date('02/02/2025').toISOString(),
      isCompleted: false
    }
    mockRequest.flush(task)
  })

  it('should create a task', () => {
    const newTask = {
      taskId: 1,
      title: 'Test',
      description: 'Test',
      dueDate: new Date('02/02/2025').toISOString(),
      isCompleted: false
    }
    service.createTask(newTask).subscribe(response => {
      expect(response).toBeTruthy()
      expect(response).toEqual(newTask)
    })
    const mockRequest = testingController.expectOne(environment.baseURL + '/api/task')
    expect(mockRequest.request.method).toEqual('POST')
    expect(mockRequest.request.body).toEqual(newTask)
    mockRequest.flush(newTask)
  })

  it('should edit a task', () => {
    const oldTask = {
      taskId: 1,
      title: 'Test',
      description: 'Test',
      dueDate: new Date('02/02/2025').toISOString(),
      isCompleted: false
    }
    const editedTask = {
      taskId: 1,
      title: 'Edited Test',
      description: 'Edited Test',
      dueDate: new Date('03/03/2025').toISOString(),
      isCompleted: true
    }
    service.editTask(editedTask).subscribe(response => {
      expect(response).toBeTruthy()
      expect(response).not.toEqual(oldTask)
    })
    const mockRequest = testingController.expectOne(environment.baseURL + '/api/task')
    expect(mockRequest.request.method).toEqual('PUT')
    mockRequest.flush(editedTask)
  })

  it('should delete a task', () => {
    service.removeTask(1).subscribe(response => {
      expect(response).toBeTruthy()
      expect(response).toBe('Task deleted successfully!')
    })
    const mockRequest = testingController.expectOne(environment.baseURL + '/api/task/1')
    expect(mockRequest.request.method).toEqual('DELETE')
    expect(mockRequest.request.responseType).toEqual('text')
    const responseMessage = 'Task deleted successfully!'
    mockRequest.flush(responseMessage)
  })
});
