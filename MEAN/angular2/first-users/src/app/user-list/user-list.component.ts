import { Component, OnInit } from '@angular/core';
import { User } from './user';
import { UserService } from './user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  users: Array<User>;

  constructor(private _userService: UserService) { }

  ngOnInit() {
    this.users = this._userService.users;
  }

}
