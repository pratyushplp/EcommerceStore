import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {PaginationModule} from 'ngx-bootstrap/pagination';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';




@NgModule({
  declarations: [PagingHeaderComponent, PagerComponent],
  imports: [
    CommonModule,
     PaginationModule.forRoot()// need forRoot as paginationModule has its own provider array and those provide module are needed at startup(i.e appcomponent)
  ],
  exports: [PaginationModule,PagingHeaderComponent,PagerComponent]
})
export class SharedModule { }
