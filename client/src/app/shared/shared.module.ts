import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';
import { ReactiveFormsModule } from '@angular/forms';
import { TextInputComponent } from './components/text-input/text-input.component';



@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent,
    TextInputComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    PaginationModule.forRoot(),
    CarouselModule.forRoot(),
    BsDropdownModule.forRoot(),
  ],
  exports: [
    ReactiveFormsModule,
    PaginationModule,
    CarouselModule,
    BsDropdownModule,
    PagingHeaderComponent,
    PagerComponent,
    TextInputComponent,
  ]
})
export class SharedModule { }
