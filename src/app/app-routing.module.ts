import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { PageNotFoundComponent } from './Components/page-not-found/page-not-found.component';
import { BooksComponent } from './Components/books/books.component';
import { CartComponent } from './Components/cart/cart.component';
import { SuccessfullCheckoutComponent } from './Components/successfull-checkout/successfull-checkout.component';
import { XBookDetailsComponent } from './Components/x-book-details/x-book-details.component';
import { XAuthorDetailsComponent } from './Components/x-author-details/x-author-details.component';
import { AdminPanelComponent } from './Components/admin-panel/admin-panel.component';
import { AdminBooksComponent } from './Components/admin-books/admin-books.component';
import { AdminGenresComponent } from './Components/admin-genres/admin-genres.component';
import { AdminOrdersComponent } from './Components/admin-orders/admin-orders.component';
import { AdminAuthorsComponent } from './Components/admin-authors/admin-authors.component';
import { AdminShippingMethodsComponent } from './Components/admin-shipping-methods/admin-shipping-methods.component';
import { AdminShippingMethodInsertComponent } from './Components/admin-shipping-method-insert/admin-shipping-method-insert.component';
import { AdminAuthorInsertComponent } from './Components/admin-author-insert/admin-author-insert.component';
import { AdminGenreInsertComponent } from './Components/admin-genre-insert/admin-genre-insert.component';
import { AdminBookInsertComponent } from './Components/admin-book-insert/admin-book-insert.component';
import { LoginComponent } from './Components/login/login.component';
import { LogoutComponent } from './Components/logout/logout.component';
import { RegisterComponent } from './Components/register/register.component';

const routes: Routes = [
  {
    path:"",
    redirectTo: "/home",
    pathMatch: "full"
  },
  {
    path:"home",
    component: HomeComponent
  },
  {
    path:"login",
    component: LoginComponent
  },
  {
    path:"register",
    component: RegisterComponent
  },
  {
    path:"logout",
    component: LogoutComponent
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
    path:"admin",
    component: AdminPanelComponent,
    children: [
      {
        path:"books",
        component: AdminBooksComponent
      },
      {
        path:"books/insert",
        component: AdminBookInsertComponent
      },
      {
        path:"genres",
        component: AdminGenresComponent
      },
      {
        path:"genres/insert",
        component: AdminGenreInsertComponent
      },
      {
        path:"orders",
        component: AdminOrdersComponent
      },
      {
        path:"authors",
        component: AdminAuthorsComponent
      },
      {
        path:"authors/insert",
        component: AdminAuthorInsertComponent
      },
      {
        path:"shipping_methods",
        component: AdminShippingMethodsComponent
      },
      {
        path:"shipping_methods/insert",
        component: AdminShippingMethodInsertComponent
      },

    ]
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
  {
    path: "**",
    component: PageNotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
