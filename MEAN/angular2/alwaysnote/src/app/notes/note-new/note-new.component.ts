import { Component, OnInit } from '@angular/core';
import { Note } from './../note';
import { NoteService } from './../note.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-note-new',
  templateUrl: './note-new.component.html',
  styleUrls: ['./note-new.component.css']
})
export class NoteNewComponent implements OnInit {
  newNote:Note = new Note();

  constructor(private _noteService: NoteService) { }

  onSubmit(formData: NgForm){
    console.log(formData.value);
    // Simpler version:
    //
    this._noteService.createNote(formData.value);
    this.newNote = new Note();
  }

  ngOnInit() {
  }

}
