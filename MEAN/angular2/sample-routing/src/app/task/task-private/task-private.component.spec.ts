import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskPrivateComponent } from './task-private.component';

describe('TaskPrivateComponent', () => {
  let component: TaskPrivateComponent;
  let fixture: ComponentFixture<TaskPrivateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TaskPrivateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskPrivateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
