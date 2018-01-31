import { Injectable } from '@angular/core';
import { Note } from './note';


@Injectable()
export class NoteService {
  notes: Array<Note> = [
    // This is being glitchy for no reason again. Fix it.
    new Note(1, "You're amazing!", new Date, new Date),
    new Note(2, "I know.", new Date, new Date),
    new Note(3, "Oh. Okay.", new Date, new Date),
    new Note(4, "But thanks anyways!", new Date, new Date),
    new Note(5, "...No problem?", new Date, new Date)
  ];
  constructor() { }

  createNote(note){
    note.id = (this.notes[this.notes.length-1].id)+1;
    note.dateCreated = new Date();
    note.dateUpdated = new Date();
    this.notes.push(note);
  }

  deleteNote(note){
    let index: number = this.notes.indexOf(note);
    if (index !== -1) {
        this.notes.splice(index, 1);
    }
  }

  editNote(note, original_note){
    let index: number = this.notes.indexOf(original_note);
    if (index !== -1) {
      let editNote: Note = new Note(original_note.id, note.note, original_note.dateCreated, new Date);
      editNote.dateUpdated = new Date();
      console.log("Edited note:", editNote);
      console.log("(Shown to show that dateUpdated is getting updated.)")
      this.notes[index] = editNote;
    }
  }

}
