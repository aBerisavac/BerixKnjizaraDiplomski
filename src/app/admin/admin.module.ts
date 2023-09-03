import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminAuthorInsertComponent } from './Components/admin-author-insert/admin-author-insert.component';
import { AdminAuthorsComponent } from './Components/admin-authors/admin-authors.component';
import { AdminPanelTableComponent } from './Components/admin-panel-table/admin-panel-table.component';
import { AdminPanelComponent } from './Components/admin-panel/admin-panel.component';
import { AdminOrdersComponent } from './Components/admin-orders/admin-orders.component';
import { AdminBooksComponent } from './Components/admin-books/admin-books.component';
import { AdminBookInsertComponent } from './Components/admin-book-insert/admin-book-insert.component';
import { AdminGenresComponent } from './Components/admin-genres/admin-genres.component';
import { AdminGenreInsertComponent } from './Components/admin-genre-insert/admin-genre-insert.component';
import { AdminShippingMethodsComponent } from './Components/admin-shipping-methods/admin-shipping-methods.component';
import { AdminShippingMethodInsertComponent } from './Components/admin-shipping-method-insert/admin-shipping-method-insert.component';
import { MatIconModule } from '@angular/material/icon';
import { SharedModule } from '../shared/shared.module';
import { AdminAuthorUpdateComponent } from './Components/admin-author-update/admin-author-update.component';
import { FormsModule } from '@angular/forms';
import { AdminGenreUpdateComponent } from './Components/admin-genre-update/admin-genre-update.component';
import { AdminShippingMethodUpdateComponent } from './Components/admin-shipping-method-update/admin-shipping-method-update.component';
import { AdminBookUpdateComponent } from './Components/admin-book-update/admin-book-update.component';
import { AdminLanguagesComponent } from './Components/admin-languages/admin-languages.component';
import { AdminLanguageInsertComponent } from './Components/admin-language-insert/admin-language-insert.component';


@NgModule({
  declarations: [
    AdminAuthorInsertComponent,
    AdminAuthorsComponent,
    AdminPanelTableComponent,
    AdminPanelComponent,
    AdminOrdersComponent,
    AdminBooksComponent,
    AdminBookInsertComponent,
    AdminGenresComponent,
    AdminGenreInsertComponent,
    AdminShippingMethodsComponent,
    AdminShippingMethodInsertComponent,
    AdminAuthorUpdateComponent,
    AdminGenreUpdateComponent,
    AdminShippingMethodUpdateComponent,
    AdminBookUpdateComponent,
    AdminLanguagesComponent,
    AdminLanguageInsertComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    MatIconModule,
    SharedModule,
    FormsModule,
  ]
})
export class AdminModule { }
