import { Component, OnInit } from '@angular/core';
import { WidgetService } from '../widget.service';
import { Response } from '@angular/http';

@Component({
  selector: 'app-widget-new',
  templateUrl: './widget-new.component.html',
  styleUrls: ['./widget-new.component.css']
})
export class WidgetNewComponent implements OnInit {
  newWidget: any = {name:''};

  constructor(private widgetComponent: WidgetService ) { }

  ngOnInit() {
  }

  create(){
    this.widgetComponent.create(this.newWidget).subscribe(
      (response: Response) => {
        this.newWidget = {name:''};
        this.widgetComponent.index();
      }
    )

  }


}
