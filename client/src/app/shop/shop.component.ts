import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { IProductBrand } from '../shared/models/ProductBrand';
import { IProductType } from '../shared/models/ProductType';
import { ShopParams } from '../shared/models/ShopParams';
import { ShopService } from './shop.service';
@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  @ViewChild('search',{static : true}) searchTerm : ElementRef; // to get the value of #search 
  products : IProduct[];
  productBrands : IProductBrand[];
  productTypes : IProductType[];
  selectedTypeId = 0;
  sortOptions = [{key:"Alphabetical", value: "NameAsc"},
                 {key:"Price: Low to High", value: "PriceAsc"},
                 {key:"Price: High to Low", value: "PriceDesc"}];
  shopParams = new ShopParams();
  totalCount : number;

  constructor(private service : ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getProductTypes();
    this.getProductBrands();
  }

  getProducts() : void 
  {
    this.service.getProducts(this.shopParams).subscribe((response) => {
    this.products = response.data
    this.shopParams.pageIndex = response.pageIndex;
    this.shopParams.pageSize = response.pageSize;
    this.totalCount = response.count; 
    console.log(response)
    }
    , (error)=> console.log(error));
  }

  getProductBrands() : void
  {
    this.service.getProductBrands().subscribe((response)=> this.productBrands = [ {name: "All", id: 0}, ...response],
     error => console.log(error));
  }

  getProductTypes() : void
  {
    this.service.getProductTypes().subscribe((response)=> this.productTypes = [ {name: "All", id: 0}, ...response], 
    error => console.log(error));
  }
  
  onBrandClick(id: number): void
  {
    this.shopParams.brandId = id;
    this.shopParams.pageIndex = 0;
    this.getProducts(); 
  }

  onTypeClick(id: number) : void
  {
    this.shopParams.typeId = id;
    this.shopParams.pageIndex = 0;
    this.getProducts(); 
  }

  onSortChange(sort : string)
  {
    console.log('sort value '+ sort)
    this.shopParams.sort = sort;
         this.shopParams.pageIndex = 0;
    this.getProducts();
  }

  onPageChanged(event: any)
  {
    //Note: the (pageChanged) property inside pagination tag of page component is fired when we apply filters as well, as the [totalItems] is changed too
   //This causes the network to call 2 api requests instead of 1. So we add a condition to check if the page is actually changed or not
   if(this.shopParams.pageIndex != (event -1))
   {
    // dotnetcore api case page index starts with 0 so -1 is needed
    // this.shopParams.pageIndex = event.page -1; // Before seperate pager component was creater
    this.shopParams.pageIndex = event -1; // after, we only need to pass event variable as the function inside pager component already passes us event with page 
    this.getProducts();

   }


  }

  onSearch()
  {
   this.shopParams.search = this.searchTerm.nativeElement.value;
    this.shopParams.pageIndex = 0;
   this.getProducts();
  }

  onReset()
  {
   this.searchTerm.nativeElement.value = "";
   this.shopParams = new ShopParams();
   this.getProducts();
  }

}

