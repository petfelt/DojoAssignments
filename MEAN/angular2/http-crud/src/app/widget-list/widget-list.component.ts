import { Component, OnInit } from '@angular/core';
import { WidgetService } from '../widget.service';
import { Response } from '@angular/http';

@Component({
  selector: 'app-widget-list',
  templateUrl: './widget-list.component.html',
  styleUrls: ['./widget-list.component.css']
})
export class WidgetListComponent implements OnInit {
  widgets: any[] = [];
  editableWidget: any;
  editEnabled: boolean = false;

  constructor(private widgetService: WidgetService) { }

  ngOnInit() {
    this.retrieveAll()
  }

  retrieveAll(){
    this.widgetService.index();
  }

  edit(widget){
    this.editEnabled = true;
    this.editableWidget = widget;
  }

  destroy(widget){
    this.widgetService.destroy(widget);
  }

}
