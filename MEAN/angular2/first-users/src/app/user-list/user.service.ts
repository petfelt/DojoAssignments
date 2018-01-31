import { Injectable } from '@angular/core';
import { User } from './user';


@Injectable()
export class UserService {
  users: Array<User> = [
    new User("Lamb", new Date()),
    new User("Schwarma", new Date()),
    new User("Delicious", new Date()),
    new User("Sandwich", new Date())
  ];
  constructor() {}

}
