import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Note } from './note';

@Injectable()
export class NoteService {
  notes: Array<Note> = [
    new Note("First Note", "This is the first note."),
    new Note("Second Note", "This is the second note.")
  ];
  constructor(private _http: Http) {
  }

  getNotes(){
    return this.notes;
  }

  createNote(note){
    this.notes.push(note);
  }

}
