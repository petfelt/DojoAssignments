import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';
import {CloudinaryModule, CloudinaryConfiguration, provideCloudinary} from '@cloudinary/angular-4.x';
import * as cloudinary from 'cloudinary-core';

import { FileUploadModule } from 'ng2-file-upload';
import {CloudinarySettings} from './settings';


import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { HomeComponent } from './components/home/home.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ProfileComponent } from './components/profile/profile.component';

import { ValidateService } from './services/validate.service';
import { AuthService } from './services/auth.service';
import { FlashMessagesModule } from 'angular2-flash-messages';
import { AuthGuard } from './guards/auth.guard';
import { EndbarComponent } from './components/endbar/endbar.component';
import { PhotosComponent } from './components/photos/photos.component';
import { ArtComponent } from './components/art/art.component';
import { MusicComponent } from './components/music/music.component';
import { SoftwareComponent } from './components/software/software.component';
import { UploaderComponent } from './components/uploader/uploader.component';

const appRoutes: Routes = [
  {path:'', component: HomeComponent},
  // {path:'register', component: RegisterComponent},
  {path:'login', component: LoginComponent},
  // {path:'dashboard', component: DashboardComponent, canActivate:[AuthGuard]},
  // {path:'profile', component: ProfileComponent, canActivate:[AuthGuard]},
  {path:'photography', component: PhotosComponent},
  {path:'art', component: ArtComponent},
  {path:'music', component: MusicComponent},
  {path:'software', component: SoftwareComponent},
  {path:'xpendx', component: SoftwareComponent},
  {path:'upload', component: UploaderComponent},

]

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    DashboardComponent,
    ProfileComponent,
    EndbarComponent,
    PhotosComponent,
    ArtComponent,
    MusicComponent,
    SoftwareComponent,
    UploaderComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(appRoutes),
    CloudinaryModule.forRoot(cloudinary, CloudinarySettings),
    FileUploadModule,
    FlashMessagesModule
  ],
  providers: [ValidateService, AuthService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
