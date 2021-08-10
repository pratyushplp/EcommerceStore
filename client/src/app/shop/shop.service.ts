import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/pagination';
import { IProductBrand } from '../shared/models/ProductBrand';
import { IProductType } from '../shared/models/ProductType';
import {map} from 'rxjs/operators'
import { ShopParams } from '../shared/models/ShopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl : string = "https://localhost:5000/api/";
  
  //DI
  constructor(private httpClient : HttpClient) { }

  getProducts( shopParams : ShopParams) {
    let params  = new HttpParams();
    if(shopParams.brandId != 0) params = params.append('brandId',shopParams.brandId.toString());
    if(shopParams.typeId !=0 )  params = params.append('typeId',shopParams.typeId.toString());
    if(shopParams.search && shopParams.search!=="") params = params.append('search', shopParams.search);

    params = params.append('sort',shopParams.sort)
    params = params.append('pageIndex',shopParams.pageIndex.toString());
    params = params.append('pageSize',shopParams.pageSize.toString());

    console.log(params)
    return this.httpClient.get<IPagination>(this.baseUrl + "product/getAll",{params});

    //alternative
    //     return this.httpClient.get<IPagination>(this.baseUrl + "product/getAll?pageSize=10",{observe :"response" ,params})
    // .pipe(
    //   map(response =>
    //     {
    //       return response.body
    //     }))
  }

  getProductBrands() {
    return this.httpClient.get<IProductBrand[]>(this.baseUrl + "productBrand/getAll");
  }

  getProductTypes() {
    return this.httpClient.get<IProductType[]>(this.baseUrl + "productType/getAll");
  }
}
