import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { WidgetComponent } from './widget/widget.component';
import { WidgetListComponent } from './widget-list/widget-list.component';
import { WidgetNewComponent } from './widget-new/widget-new.component';
import { WidgetEditComponent } from './widget-edit/widget-edit.component';

import { HttpService } from './http.service';
import { WidgetService } from './widget.service';

@NgModule({
  declarations: [
    AppComponent,
    WidgetComponent,
    WidgetListComponent,
    WidgetNewComponent,
    WidgetEditComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule
  ],
  providers: [WidgetService, HttpService],
  bootstrap: [AppComponent]
})

export class AppModule { }
