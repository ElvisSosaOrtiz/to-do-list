import { ChangeDetectionStrategy, Component, EventEmitter, inject, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { RouterLink } from '@angular/router';
import { MatInputModule } from '@angular/material/input'
import { MatButtonModule } from '@angular/material/button';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { provideNativeDateAdapter } from '@angular/material/core';
import { ITask } from '../models/task.models';

@Component({
  selector: 'app-task-form',
  imports: [RouterLink, ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatDatepickerModule],
  providers: [provideNativeDateAdapter()],
  templateUrl: './task-form.component.html',
  styleUrl: './task-form.component.css'
})
export class TaskFormComponent implements OnInit {
  private readonly formBuilder = inject(FormBuilder)

  @Input({required: true})
  pageTitle!: string

  @Input()
  taskModel?: ITask

  @Output()
  submitForm = new EventEmitter<ITask>()

  form = this.formBuilder.group({
    title: ['', [Validators.required]],
    description: ['', [Validators.required]],
    dueDate: ['', [Validators.required]]
  })

  ngOnInit(): void {
    if (this.taskModel !== undefined) {
      this.form.patchValue(this.taskModel)
    }
  }

  saveChanges() {
    let task = this.form.value as ITask
    if (task.taskId === undefined) {
      task.taskId = this.taskModel?.taskId!
    }
    this.submitForm.emit(task)
  }
}