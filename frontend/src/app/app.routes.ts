import { Routes } from '@angular/router';
import { TaskListComponent } from './task-list/task-list.component';
import { TaskDetailsComponent } from './task-details/task-details.component';
import { CreateTaskComponent } from './create-task/create-task.component';
import { EditTaskComponent } from './edit-task/edit-task.component';

export const routes: Routes = [
    { path: '', component: TaskListComponent },
    { path: 'task-create', component: CreateTaskComponent },
    { path: 'task-edit/:taskId', component: EditTaskComponent },
    { path: 'task-details/:taskId', component: TaskDetailsComponent }
];
