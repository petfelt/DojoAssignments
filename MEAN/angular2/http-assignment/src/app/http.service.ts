import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Task } from './tasks/task';
import "rxjs";

@Injectable()
export class HttpService {

  constructor(private _http: Http) { }

  index() {
    return this._http.get('https://api-http.firebaseio.com/tasks.json')
      .map((response: Response) => response.json())
  }
  // destroy(task){
  //   return this._http.delete('https://api-http.firebaseio.com/tasks/#{task.id}.json')
  // }


  create(newTask: any) {
    JSON.stringify(newTask);
    return this._http.post('https://api-http.firebaseio.com/tasks.json', newTask);
  }


  indexPromise(){
    return this._http.get('https://api-http.firebaseio.com/tasks.json')
      .toPromise();
  }

}
