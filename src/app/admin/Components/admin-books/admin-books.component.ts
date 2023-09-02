import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IBookAdmin } from 'src/app/Interfaces/IBookAdmin';
import { BooksService } from 'src/app/Services/books.service';
import { BookDTO } from 'src/tsBusinessLayer/dtos/BookDTO';

@Component({
  selector: 'app-admin-books',
  templateUrl: './admin-books.component.html',
  styleUrls: ['./admin-books.component.scss'],
})
export class AdminBooksComponent implements OnInit {
  public jsonObjectArrayToDisplay: Array<IBookAdmin> = [];

  constructor(
    private _booksService: BooksService,
    private _router: Router,
  ) {}

  ngOnInit(): void {
    this._booksService.books$.subscribe((x) =>
      this.convertBooksDTOToIBookAdmin(x)
    );
  }

  convertBooksDTOToIBookAdmin(books: BookDTO[]) {
    this.jsonObjectArrayToDisplay = [];
    for (let book of books) {
      let price = book.Prices[0].price;

      let genres = '';
      book.Genres.forEach((x) => (genres += `${x.Name}, `));
      genres = genres.slice(0, genres.length - 2);

      let authors = '';
      book.Authors.forEach(
        (x) => (authors += `${x.FirstName} ${x.LastName}, `)
      );
      authors = authors.slice(0, authors.length - 2);
      genres = genres.slice(0, genres.length - 2);

      let languages = '';
      book.Languages.forEach((x) => (languages += `${x.Name}, `));
      languages = languages.slice(0, languages.length - 2);

      this.jsonObjectArrayToDisplay.push({
        id: book.id,
        Title: book.Title,
        'Release date': formatDate(book.ReleaseDate, 'MMM d, y', 'en'),
        'Book price': price,
        Authors: authors,
        Genres: genres,
        Languages: languages,
      } as IBookAdmin);
    }
  }

  editItem(item: IBookAdmin) {
    this._router.navigateByUrl(`${this._router.url}/edit/${item.id}`)
  }

  deleteItem(item: IBookAdmin) {
    this._booksService.deleteBook(item.id);
  }
}
