import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule  } from '@angular/common/http/testing'

import { CreateTaskComponent } from './create-task.component';
import { RouterModule } from '@angular/router';
import { provideAnimations } from '@angular/platform-browser/animations';

describe('CreateTaskComponent', () => {
  let component: CreateTaskComponent;
  let fixture: ComponentFixture<CreateTaskComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateTaskComponent, HttpClientTestingModule, RouterModule.forRoot([])],
      providers: [provideAnimations()]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateTaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
