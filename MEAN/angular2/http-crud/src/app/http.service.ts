import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import "rxjs";

@Injectable()
export class HttpService {

  constructor(private _http: Http) { }

  index() {
    return this._http.get('https://api-http.firebaseio.com/widgets.json')
      .map((response: Response) => response.json())
  }

  create(widget: any) {
    return this._http.post('https://api-http.firebaseio.com/widgets.json', widget)
  }

  update(widget: any) {
    return this._http.put('https://api-http.firebaseio.com/widgets.json', widget)
  }

  destroy(widget: any) {
    return this._http.delete('https://api-http.firebaseio.com/widgets/'+widget.id+'/id.json')
  }


}
