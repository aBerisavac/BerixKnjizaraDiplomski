import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationComponent } from './Components/navigation/navigation.component';
import { FooterComponent } from './Components/footer/footer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule} from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { HomeComponent } from './Components/home/home.component';
import { PageNotFoundComponent } from './Components/page-not-found/page-not-found.component';
import { BooksComponent } from './Components/books/books.component';
import { XBookComponent } from './Components/x-book/x-book.component';
import { CartComponent } from './Components/cart/cart.component';
import { CartPopupComponent } from './Components/cart-popup/cart-popup.component';
import { CheckoutDialogComponent } from './Components/checkout-dialog/checkout-dialog.component';
import { SuccessfullCheckoutComponent } from './Components/successfull-checkout/successfull-checkout.component';
import { XBookDetailsComponent } from './Components/x-book-details/x-book-details.component';
import { XAuthorDetailsComponent } from './Components/x-author-details/x-author-details.component';
import { PopupBottomRightComponent } from './Components/popup-bottom-right/popup-bottom-right.component';
import { AdminPanelComponent } from './Components/admin-panel/admin-panel.component';
import { AdminBooksComponent } from './Components/admin-books/admin-books.component';
import { AdminGenresComponent } from './Components/admin-genres/admin-genres.component';
import { AdminAuthorsComponent } from './Components/admin-authors/admin-authors.component';
import { AdminShippingMethodsComponent } from './Components/admin-shipping-methods/admin-shipping-methods.component';
import { AdminOrdersComponent } from './Components/admin-orders/admin-orders.component';
import { AdminPanelTableComponent } from './Components/admin-panel-table/admin-panel-table.component';
import { AdminShippingMethodInsertComponent } from './Components/admin-shipping-method-insert/admin-shipping-method-insert.component';
import { AdminAuthorInsertComponent } from './Components/admin-author-insert/admin-author-insert.component';
import { AdminGenreInsertComponent } from './Components/admin-genre-insert/admin-genre-insert.component';
import { AdminBookInsertComponent } from './Components/admin-book-insert/admin-book-insert.component';
import { ErrorModalComponent } from './Components/error-modal/error-modal.component';
import { LoginComponent } from './Components/login/login.component';
import { LogoutComponent } from './Components/logout/logout.component';
import { RegisterComponent } from './Components/register/register.component'

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    FooterComponent,
    HomeComponent,
    PageNotFoundComponent,
    BooksComponent,
    XBookComponent,
    CartComponent,
    CartPopupComponent,
    CheckoutDialogComponent,
    SuccessfullCheckoutComponent,
    XBookDetailsComponent,
    XAuthorDetailsComponent,
    PopupBottomRightComponent,
    AdminPanelComponent,
    AdminBooksComponent,
    AdminGenresComponent,
    AdminAuthorsComponent,
    AdminShippingMethodsComponent,
    AdminOrdersComponent,
    AdminPanelTableComponent,
    AdminShippingMethodInsertComponent,
    AdminAuthorInsertComponent,
    AdminGenreInsertComponent,
    AdminBookInsertComponent,
    ErrorModalComponent,
    LoginComponent,
    LogoutComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatIconModule,
    HttpClientModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
