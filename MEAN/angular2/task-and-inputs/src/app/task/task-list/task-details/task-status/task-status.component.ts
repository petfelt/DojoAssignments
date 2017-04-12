import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-task-status',
  templateUrl: './task-status.component.html',
  styleUrls: ['./task-status.component.css']
})


export class TaskStatusComponent implements OnInit {
  toggler: number;
  completer: string = "Incomplete";
  buttoncompleter: string = "Click to Complete";

  constructor() { }

  toggleClass(newValue: number) {
    if (this.toggler === newValue) {
      this.toggler = 0;
      this.completer = "Incomplete";
      this.buttoncompleter = "Click to Complete";
    }
    else {
      this.toggler = newValue;
      this.completer = "Completed";
      this.buttoncompleter = "Click to mark Incomplete";
    }
  }

  ngOnInit() {
  }

}
