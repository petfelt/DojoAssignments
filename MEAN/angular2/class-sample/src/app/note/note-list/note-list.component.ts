import { Component, OnInit } from '@angular/core';
import { Note } from './../note';
import { NoteService } from './../note.service';

@Component({
  selector: 'app-note-list',
  templateUrl: './note-list.component.html',
  styleUrls: ['./note-list.component.css']
})
export class NoteListComponent implements OnInit {
  notes: Array<Note>;

  constructor(private _noteService: NoteService) { }

  ngOnInit() {
    this.notes = this._noteService.notes;
  }

}
