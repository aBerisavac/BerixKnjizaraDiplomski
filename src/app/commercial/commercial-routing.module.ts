import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { XBookDetailsComponent } from './x-book-details/x-book-details.component';
import { XAuthorDetailsComponent } from './x-author-details/x-author-details.component';
import { BooksComponent } from './books/books.component';
import { CartComponent } from './cart/cart.component';
import { SuccessfullCheckoutComponent } from './successfull-checkout/successfull-checkout.component';

const routes: Routes = [
  {
    path:'',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path:"home",
    component: HomeComponent
  },
  {
    path:"book/:id",
    component: XBookDetailsComponent
  },
  {
    path:"author/:id",
    component: XAuthorDetailsComponent
  },
{
    path:"books",
    component: BooksComponent
  },
  {
    path:"shopping_cart",
    component: CartComponent
  },
  {
    path:"successfull_checkout",
    component: SuccessfullCheckoutComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CommercialRoutingModule { }
