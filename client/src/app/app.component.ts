import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './models/pagination';
import { IProduct } from './models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
   title = 'client';
   products : IProduct[]; 

   constructor(private httpClient :HttpClient) {
   }


    ngOnInit(): void 
    {
      this.httpClient.get('https://localhost:5001/api/product/getAll')
      .subscribe( (response : IPagination)=> {this.products= response.data 
      console.log(this.products)}
      , (error: unknown)=> console.log(error) );
    }


  
  
}
