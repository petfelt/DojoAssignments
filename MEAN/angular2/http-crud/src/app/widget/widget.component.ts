import { Component, OnInit } from '@angular/core';
import { WidgetService } from '../widget.service';
import { Widget } from '../widget';

@Component({
  selector: 'app-widget',
  templateUrl: './widget.component.html',
  styleUrls: ['./widget.component.css']
})
export class WidgetComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
