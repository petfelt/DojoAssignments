import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { WidgetService } from '../widget.service';

@Component({
  selector: 'app-widget-edit',
  templateUrl: './widget-edit.component.html',
  styleUrls: ['./widget-edit.component.css']
})
export class WidgetEditComponent implements OnInit, OnChanges {
  @Input() widget: any;

  editableWidget: any = {name:''};

  constructor(private widgetService: WidgetService) { }

  ngOnInit() {
    this.editableWidget.name = this.widget.name;
  }

  ngOnChanges(){
    this.editableWidget.name = this.widget.name;
  }

  update() {
    this.widgetService.update(this.editableWidget, this.widget);
  }

}
