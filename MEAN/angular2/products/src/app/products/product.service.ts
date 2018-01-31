import { Injectable } from '@angular/core';
import { Product } from './product';


@Injectable()
export class ProductService {
  products: Array<Product> = [
    new Product("Keyboard", "Like New", 124.99, 500, new Date(), new Date()),
    new Product("Nike Shoes", "Heavily Used", 3.99, 2, new Date(), new Date()),
    new Product("Diamonds", "Freshly Minted", 1000000.56, 100, new Date(), new Date())
  ];
  constructor() { }

  createProduct(product){
    product.dateCreated = new Date();
    product.dateUpdated = new Date();
    this.products.push(product);
  }

  deleteProduct(product){
    let index: number = this.products.indexOf(product);
    if (index !== -1) {
        this.products.splice(index, 1);
    }
  }

}
