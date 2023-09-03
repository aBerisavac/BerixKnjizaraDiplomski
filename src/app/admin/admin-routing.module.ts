import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminAuthorsComponent } from './Components/admin-authors/admin-authors.component';
import { AdminAuthorInsertComponent } from './Components/admin-author-insert/admin-author-insert.component';
import { AdminBooksComponent } from './Components/admin-books/admin-books.component';
import { AdminBookInsertComponent } from './Components/admin-book-insert/admin-book-insert.component';
import { AdminGenresComponent } from './Components/admin-genres/admin-genres.component';
import { AdminGenreInsertComponent } from './Components/admin-genre-insert/admin-genre-insert.component';
import { AdminOrdersComponent } from './Components/admin-orders/admin-orders.component';
import { AdminShippingMethodsComponent } from './Components/admin-shipping-methods/admin-shipping-methods.component';
import { AdminShippingMethodInsertComponent } from './Components/admin-shipping-method-insert/admin-shipping-method-insert.component';
import { AdminPanelComponent } from './Components/admin-panel/admin-panel.component';
import { AdminAuthorUpdateComponent } from './Components/admin-author-update/admin-author-update.component';
import { AdminGenreUpdateComponent } from './Components/admin-genre-update/admin-genre-update.component';
import { AdminShippingMethodUpdateComponent } from './Components/admin-shipping-method-update/admin-shipping-method-update.component';
import { AdminBookUpdateComponent } from './Components/admin-book-update/admin-book-update.component';
import { AdminLanguagesComponent } from './Components/admin-languages/admin-languages.component';
import { AdminLanguageInsertComponent } from './Components/admin-language-insert/admin-language-insert.component';

const routes: Routes = [
  {
    path:'',
    redirectTo: 'panel/orders',
    pathMatch: 'full'
  },
  {
    path:"panel",
    component: AdminPanelComponent,
    children: [
      {
        path:"authors",
        component: AdminAuthorsComponent
      },
      {
        path:"authors/insert",
        component: AdminAuthorInsertComponent
      },
      {
        path:"authors/edit/:id",
        component: AdminAuthorUpdateComponent
      },
      {
        path:"books",
        component: AdminBooksComponent
      },
      {
        path:"books/insert",
        component: AdminBookInsertComponent
      },
      {
        path:"books/edit/:id",
        component: AdminBookUpdateComponent
      },
      {
        path:"languages",
        component: AdminLanguagesComponent
      },
      {
        path:"languages/insert",
        component: AdminLanguageInsertComponent
      },
      {
        path:"genres",
        component: AdminGenresComponent
      },
      {
        path:"genres/edit/:id",
        component: AdminGenreUpdateComponent
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
        path:"shipping_methods",
        component: AdminShippingMethodsComponent
      },
      {
        path:"shipping_methods/edit/:id",
        component: AdminShippingMethodUpdateComponent
      },
      {
        path:"shipping_methods/insert",
        component: AdminShippingMethodInsertComponent
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
