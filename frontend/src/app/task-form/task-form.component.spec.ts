import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule  } from '@angular/common/http/testing'

import { TaskFormComponent } from './task-form.component';
import { provideAnimations } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';

describe('TaskFormComponent', () => {
  let component: TaskFormComponent;
  let fixture: ComponentFixture<TaskFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TaskFormComponent, HttpClientTestingModule, RouterModule.forRoot([])],
      providers: [provideAnimations()]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TaskFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
