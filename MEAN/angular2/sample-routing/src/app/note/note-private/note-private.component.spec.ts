import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NotePrivateComponent } from './note-private.component';

describe('NotePrivateComponent', () => {
  let component: NotePrivateComponent;
  let fixture: ComponentFixture<NotePrivateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NotePrivateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NotePrivateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
