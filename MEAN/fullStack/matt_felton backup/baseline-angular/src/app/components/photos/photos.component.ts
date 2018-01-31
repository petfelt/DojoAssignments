import { Component, OnInit } from '@angular/core';

import { DB } from '../../database';

@Component({
  selector: 'app-photos',
  templateUrl: './photos.component.html',
  styleUrls: ['./photos.component.css']
})
export class PhotosComponent implements OnInit {
  public imageDataArray;
    public activeImage;
    constructor() { }

    ngOnInit() {
      this.loadDB();
      this.loadUploadedImages();
    }

    loadDB(): void {
      DB.loadDatabase({}, function(err) {
        if (err) {
          console.log();
        } else {
          console.log('db loaded');
        }
      });
    }

    loadUploadedImages(): void {
      const imageCollection = DB.getCollection('imagegallery');

      if (imageCollection) {
        this.imageDataArray = imageCollection.find();
        if (this.imageDataArray.length > 0) {
          this.activeImage = this.imageDataArray[0];
        }
      }
    }

    updateActiveImage(index): void {
      this.activeImage = this.imageDataArray[index];
    }
  }
