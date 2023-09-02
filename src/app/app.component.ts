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
    }
  ngOnInit(): void {
    this._authorsService.getAuthors();
    this._genresService.getGenres();
    this._shippingMethodsService.getShippingMethods();
    this._booksService.getBooks();
    this._languageService.getLanguages();
    this._booksService.books$.subscribe((x)=>{
      if(x.length>0) {
        this._ordersService.getOrders(); 
      } 
  })
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
