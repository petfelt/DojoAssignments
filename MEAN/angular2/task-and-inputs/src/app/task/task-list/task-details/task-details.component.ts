import { Component, OnInit, Input } from '@angular/core';
import { TaskListComponent } from '../task-list.component';
import { detailTitles } from '../task-list.component';

@Component({
  selector: 'app-task-details',
  templateUrl: './task-details.component.html',
  styleUrls: ['./task-details.component.css']
})
export class TaskDetailsComponent implements OnInit {
  taskTitle:string;
  @Input() shifter: number;

  constructor() {
  }

  ngOnInit() {
    this.taskTitle = detailTitles[this.shifter];
  }

}
