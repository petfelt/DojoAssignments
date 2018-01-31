import { Component, OnInit } from '@angular/core';
import { User } from './../user';
import { UserService } from './../user.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  newUser:User = new User();
  submittedUser:string[] = ["",""];

  constructor(private _userService: UserService) { }

  onSubmit(formData: NgForm){
    console.log("Validated successfully!");
    console.log("Data:",formData.value);
    // Simpler version:
    //
    this.submittedUser = [formData.value.firstName, formData.value.lastName];
    this.newUser = new User();
    formData.reset();
  }

  ngOnInit() {
  }

}
