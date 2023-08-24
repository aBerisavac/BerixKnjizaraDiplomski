import { formatDate } from '@angular/common';
import { Component } from '@angular/core';
import { IBookAdmin } from 'src/app/Interfaces/IBookAdmin';
import { BooksService } from 'src/app/Services/books.service';
import { ErrorModalService } from 'src/app/Services/error-modal.service';
import { BookDTO } from 'src/tsBusinessLayer/dtos/BookDTO';

@Component({
  selector: 'app-admin-books',
  templateUrl: './admin-books.component.html',
  styleUrls: ['./admin-books.component.scss']
})
export class AdminBooksComponent {
  private books: Array<BookDTO> = [];
  public jsonObjectArrayToDisplay: Array<IBookAdmin> = [];

  constructor(private _booksService: BooksService, private _errorModalService: ErrorModalService) {
    this.convertBooksDTOToIBookAdmin();
  }

  convertBooksDTOToIBookAdmin(){
    this.books = this._booksService.getBooks() as Array<BookDTO>;
    for (let book of this.books) {

      let price = book.BookPrices[0].Price;

      let genres="";
      book.Genres.forEach(x=>genres+= `${x.Name}, `)
      genres=genres.slice(0, genres.length-2)

      let authors="";
      book.Authors.forEach(x=>authors+= `${x.FirstName} ${x.LastName}, `)
      authors=authors.slice(0, authors.length-2)
      genres=genres.slice(0, genres.length-2)

      let languages="";
      book.Languages.forEach(x=>languages+= `${x.Name}, `)
      languages=languages.slice(0, languages.length-2)

      this.jsonObjectArrayToDisplay.push({
        "id": book.id,
        "Title": book.Title,
        "Release date": formatDate(book.ReleaseDate, 'MMM d, y', 'en'),
        "Book price": price,
        "Authors": authors,
        "Genres": genres,
        "Languages": languages,
      } as IBookAdmin);
    }
  }

  editItem(item: IBookAdmin) {
    console.log(item);
  }

  deleteItem(item: IBookAdmin) {
    let errors = this._booksService.deleteBook(item.id);

    if(errors.length>0){
      this._errorModalService.setErrors(errors);
    } else{
      this.jsonObjectArrayToDisplay=[];
      this.convertBooksDTOToIBookAdmin();
    }
  }
}
