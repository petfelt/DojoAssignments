import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NotePublicComponent } from './note-public.component';

describe('NotePublicComponent', () => {
  let component: NotePublicComponent;
  let fixture: ComponentFixture<NotePublicComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NotePublicComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NotePublicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
