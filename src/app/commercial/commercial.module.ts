import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CommercialRoutingModule } from './commercial-routing.module';
import { BooksComponent } from './books/books.component';
import { XBookComponent } from './x-book/x-book.component';
import { XBookDetailsComponent } from './x-book-details/x-book-details.component';
import { MatIconModule } from '@angular/material/icon';
import { XAuthorDetailsComponent } from './x-author-details/x-author-details.component';
import { CartComponent } from './cart/cart.component';
import { CheckoutDialogComponent } from './checkout-dialog/checkout-dialog.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { SuccessfullCheckoutComponent } from './successfull-checkout/successfull-checkout.component';


@NgModule({
  declarations: [
    BooksComponent,
    XBookComponent,
    XBookDetailsComponent,
    XAuthorDetailsComponent,
    CartComponent,
    CheckoutDialogComponent,
    FooterComponent,
    HomeComponent,
    SuccessfullCheckoutComponent
  ],
  imports: [
    CommonModule,
    CommercialRoutingModule,
    MatIconModule
  ],
  exports: [
    FooterComponent,
  ]
})
export class CommercialModule { }
