import { Component, OnInit } from '@angular/core';
import { UsersService } from 'src/app/Services/users.service';
import { AuthorsService } from './Services/authors.service';
import { GenresService } from './Services/genres.service';
import { LanguagesService } from './Services/languages.service';
import { BooksService } from './Services/books.service';
import { ShippingMethodsService } from './Services/shipping-methods.service';
import { OrdersService } from './Services/orders.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'Berix Library';

  constructor(
    private _usersService: UsersService,
    private _authorsService: AuthorsService,
    private _languageService: LanguagesService,
    private _genresService: GenresService,
    private _shippingMethodsService: ShippingMethodsService,
    private _booksService: BooksService,
    private _ordersService: OrdersService,
    ){
      _authorsService.getAuthors();
      _genresService.getGenres();
      _shippingMethodsService.getShippingMethods();
      _booksService.getBooks();
      _languageService.getLanguages();
    }
  ngOnInit(): void {
    this._booksService.books$.subscribe(x=>this._ordersService.getOrders())
  }

  public onActivate(event: Event) {
    let scrollToTop = window.setInterval(() => {
        let pos = window.scrollY;
        if (pos > 0) {
            window.scrollTo(0, pos - 20); // how far to scroll on each step
        } else {
            window.clearInterval(scrollToTop);
        }
    }, 16);
}
}
