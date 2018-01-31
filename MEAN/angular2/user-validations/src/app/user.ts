export class User {
  constructor(
    public firstName: string = "",
    public lastName: string = "",
    public email: string = "",
    public password: string = "",
    public confirmPassword: string = "",
    public dateCreated: Date = new Date(),
    public dateUpdated: Date = new Date()
  ){}
}
