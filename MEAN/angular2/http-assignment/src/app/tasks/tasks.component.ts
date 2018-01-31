import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Response } from '@angular/http';
import { Task } from './task';
import { Observable } from 'rxjs';
import "rxjs";

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {
  newTask: any = new Task(0,"","");
  tasks: any[];
  private data: Observable<Array<number>>;
  myObservable: Observable<number>;

  constructor(private httpService: HttpService) { }

  ngOnInit() {
    this.index();
  }

  index(){
    // Observable
    this.httpService.index()
    .subscribe(
      (data: any) => {
        console.log("SUCCESS EXECUTED")
        var temp = [];
        for (var key in data) {
          if (data.hasOwnProperty(key)) {
            temp.push(data[key]);
            data[key].id = key;
          }
        }
        this.tasks = temp;
      },
      (err: Error) => { console.log("ERROR EXECUTED") },
      () => { console.log("NEXT EXECUTED")}
    )
  }

  create(){
    this.httpService.create(this.newTask)
    .subscribe(
      (data: Response) => console.log(data),
      (error: any) => null,
      () => this.index()
    )
    this.newTask = new Task(0,"","");
  }

  createPromise(){
    // Promise
    this.httpService.indexPromise()
    .then(
      (data: Response) => console.log(data.json()),
      (err) => console.log(err)
    )
    .catch((err: Response) => console.log(err))
  }

}
