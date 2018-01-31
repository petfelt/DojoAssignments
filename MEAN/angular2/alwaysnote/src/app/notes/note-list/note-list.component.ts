import { Component, OnInit } from '@angular/core';
import { Note } from './../note';
import { NoteService } from './../note.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-note-list',
  templateUrl: './note-list.component.html',
  styleUrls: ['./note-list.component.css']
})
export class NoteListComponent implements OnInit {
  notes: Array<Note>;
  editNote:Note = new Note();
  originalNote:Note = new Note();

  constructor(private _noteService: NoteService) { }

  ngOnInit() {
    this.notes = this._noteService.notes;
  }

  public delete(event, note){
    this._noteService.deleteNote(note);
  }

  public edit(event, note){
    this.editNote = new Note(note.id, note.note, note.dateCreated, note.dateUpdated);
    this.originalNote = note;
  }

  public cancel(event){
    this.editNote = new Note();
    this.originalNote = new Note();
    // Attempted code to get rid of errors after cancelling.
    // var l = event.target.parentElement.parentElement.getElementsByClassName("editMe");
    // var m = event.target.parentElement.getElementsByClassName("editMe");
    //
    // var count = l.length;
    // for(var i=0;i<count;i++){
    //   l[i].className = "editMe ng-valid";
    // }
    // count = m.length
    // for(var i=0;i<count;i++){
    //   m[i].className = "editMe ng-valid";
    // }
  }

  onSubmit(formData: NgForm){
    this._noteService.editNote(formData.value, this.originalNote);
    this.editNote = new Note();
    this.originalNote = new Note();

  }

}
