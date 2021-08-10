export class ShopParams{
    
    brandId : number = 0;
    typeId : number = 0;
    sort :string = 'NameAsc';
    pageIndex : number = 0;
    pageSize : number = 4;
    search : string;    
}

// this.service.getProducts(this.selectedBrandId, this.selectedTypeId, this.selectedSort).subscribe((response) => {this.products = response.data 
