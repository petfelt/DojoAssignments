export class Product {
  constructor(
    public name: string = "",
    public description: string = "",
    public price: number = 0.00,
    public quantity: number = 1,
    public dateCreated: Date = new Date(),
    public dateUpdated: Date = new Date()
  ){}
}
