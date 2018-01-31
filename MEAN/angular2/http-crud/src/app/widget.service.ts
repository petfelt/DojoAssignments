import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import "rxjs";

@Injectable()
export class WidgetService {
  widgets: any[];

  constructor(private _http: Http) { }

  index() {
    return this._http.get('https://api-http.firebaseio.com/widgets.json')
      .map((response: Response) => response.json())
      .subscribe(
      (responseObject: Response) => {
        var tempArray = [];
        for (var key in responseObject) {
          if (responseObject.hasOwnProperty(key)) {
            responseObject[key].id = key;
            tempArray.push(responseObject[key]);
          }
        }
        this.widgets = tempArray;
      },
      (error: Error) => console.log(error),
      ()=> {

      }
    )
  }

  create(widget: any) {
    return this._http.post('https://api-http.firebaseio.com/widgets.json', widget)
  }

  update(editableWidget: any, widget: any) {
    //   curl -X PATCH -d '{"last":"Jones"}' \
    //  'https://samplechat.firebaseio-demo.com/users/jack/name/.json'
    return this._http.put('https://api-http.firebaseio.com/widgets/'+widget.id+'/.json', editableWidget)
    .subscribe((response: Response)=> this.index())
  }

  destroy(widget: any) {
    return this._http.delete('https://api-http.firebaseio.com/widgets/'+widget.id+'/.json')
    .subscribe((response: Response)=> this.index())
  }

}
