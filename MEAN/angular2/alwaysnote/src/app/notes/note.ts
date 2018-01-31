export class Note {
  constructor(
    public id: number = 0,
    public note: string = "",
    public dateCreated: Date = new Date(),
    public dateUpdated: Date = new Date()
  ){}
}
