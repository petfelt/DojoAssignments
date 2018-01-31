// app.routes.ts (Route Configurations)
import { Routes, RouterModule } from '@angular/router';
import { TaskComponent } from './task/task.component';
import { NoteComponent } from './note/note.component';
import { TaskPrivateComponent } from './task/task-private/task-private.component';
import { TaskPublicComponent } from './task/task-public/task-public.component';
import { NotePublicComponent } from './note/note-public/note-public.component';
import { NotePrivateComponent } from './note/note-private/note-private.component';

const APP_ROUTES: Routes = [
    { path: '', redirectTo: '/note', pathMatch: 'full' },
    { path: 'task', component: TaskComponent,
        children: [
            { path: 'public', component: TaskPublicComponent },
            { path: 'private', component: TaskPrivateComponent }
        ]
    },
    { path: 'note', component: NoteComponent,
        children: [
            { path: 'public', component: NotePublicComponent },
            { path: 'private', component: NotePrivateComponent }
        ]
    }
];
export const routing = RouterModule.forRoot(APP_ROUTES);
