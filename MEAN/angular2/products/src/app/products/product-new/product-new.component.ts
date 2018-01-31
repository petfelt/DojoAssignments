import { Component, OnInit } from '@angular/core';
import { Product } from './../product';
import { ProductService } from './../product.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-product-new',
  templateUrl: './product-new.component.html',
  styleUrls: ['./product-new.component.css']
})

export class ProductNewComponent implements OnInit {
  newProduct:Product = new Product();

  constructor(private _productService: ProductService) { }

  onSubmit(formData: NgForm){
    console.log(formData.value);
    // Simpler version:
    //
    this._productService.createProduct(formData.value);
    this.newProduct = new Product();
  }

  ngOnInit() {
  }

}
