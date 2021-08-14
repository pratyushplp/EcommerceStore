import { error } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/shared/models/product';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  product :IProduct;
  //ActivatedRoute gives access to routes parameters
  constructor(private service : ShopService, private activeRoute: ActivatedRoute) 
  {


  }

  ngOnInit(): void 
  {
    this.onLoadDetails();
  }

  onLoadDetails()
  {
    //'+' is a shorthand symbol to convert string to int
    //the id comes from route present in approuting model.
    this.service.getProduct(+this.activeRoute.snapshot.paramMap.get('id')).subscribe((value) => 
    { this.product = value 
    console.log(value)
    },
      error => console.log(error) )
  }

}
