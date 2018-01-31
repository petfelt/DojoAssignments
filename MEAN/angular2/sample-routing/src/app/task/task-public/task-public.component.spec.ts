import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskPublicComponent } from './task-public.component';

describe('TaskPublicComponent', () => {
  let component: TaskPublicComponent;
  let fixture: ComponentFixture<TaskPublicComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TaskPublicComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskPublicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
