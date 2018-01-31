import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { routing } from './app.routes';

import { AppComponent } from './app.component';
import { TaskComponent } from './task/task.component';
import { NoteComponent } from './note/note.component';
import { TaskPrivateComponent } from './task/task-private/task-private.component';
import { TaskPublicComponent } from './task/task-public/task-public.component';
import { NotePublicComponent } from './note/note-public/note-public.component';
import { NotePrivateComponent } from './note/note-private/note-private.component';

@NgModule({
  declarations: [
    AppComponent,
    TaskComponent,
    NoteComponent,
    TaskPrivateComponent,
    TaskPublicComponent,
    NotePublicComponent,
    NotePrivateComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    routing
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
