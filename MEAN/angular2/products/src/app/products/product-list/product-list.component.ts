import { Component, OnInit } from '@angular/core';
import { Product } from './../product';
import { ProductService } from './../product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: Array<Product>;

  constructor(private _productService: ProductService) { }

  ngOnInit() {
    this.products = this._productService.products;
  }

  public clicked(event, product){
    this._productService.deleteProduct(product);
  }

}
