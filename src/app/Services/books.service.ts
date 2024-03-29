import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {
  capitalizePropertyNamesWithoutIdCapitalization,
  convertBase64ToFile,
} from 'common';
import { BehaviorSubject, Observable, catchError, of } from 'rxjs';
import { AuthorDTO } from 'src/tsBusinessLayer/dtos/AuthorDTO';
import { BookDTO } from 'src/tsBusinessLayer/dtos/BookDTO';
import { GenreDTO } from 'src/tsBusinessLayer/dtos/GenreDTO';
import { LanguageDTO } from 'src/tsBusinessLayer/dtos/LanguageDTO';
import { UsersService } from './users.service';
import { ErrorModalService } from './error-modal.service';
import { IValidationError } from 'src/tsBusinessLayer/interfaces/IValidationError';

@Injectable({
  providedIn: 'root',
})
export class BooksService {
  constructor(
    private _http: HttpClient,
    private _userService: UsersService,
    private _errorModalService: ErrorModalService
  ) {}

  private books = new BehaviorSubject<Array<BookDTO>>([]);
  public books$ = this.books.asObservable();

  getBooks() {
    this._http
      .get<any>('http://localhost:5000/api/book')
      .pipe(
        catchError((error: any, caught: Observable<any>): Observable<any> => {
          console.log(error);

          return of();
        })
      )
      .subscribe({
        next: (data) => {
          const contentType = 'image/jpeg';

          let booksFromBack: Array<BookDTO> = [];
          for (let book of data) {
            book.imageBase64 = book.image;

            let authorsFromBook: Array<AuthorDTO> = [];
            for (let author of book.authors) {
              authorsFromBook.push(
                capitalizePropertyNamesWithoutIdCapitalization(
                  author
                ) as AuthorDTO
              );
            }
            book.authors = authorsFromBook;

            let genresFromBook: Array<GenreDTO> = [];
            for (let genre of book.genres) {
              genresFromBook.push(
                capitalizePropertyNamesWithoutIdCapitalization(
                  genre
                ) as GenreDTO
              );
            }
            book.genres = genresFromBook;

            let languagesFromBook: Array<LanguageDTO> = [];
            for (let language of book.languages) {
              languagesFromBook.push(
                capitalizePropertyNamesWithoutIdCapitalization(
                  language
                ) as LanguageDTO
              );
            }
            book.languages = languagesFromBook;

            booksFromBack.push(
              capitalizePropertyNamesWithoutIdCapitalization(book) as BookDTO
            );
          }

          this.books.next(booksFromBack);
        },
      });
  }

  getBook(id: number): BookDTO {
    if(this.books.getValue().length==0){
      this.getBooks();
    }
    return this.books.getValue().filter((x) => x.id == id)[0];
  }

  getBooksWrittenByAuthor(id: number): BookDTO[] {
    let booksWrittenByAuthor: BookDTO[] = [];

    this.books.getValue().forEach((x) => {
      if (x.Authors.filter((y) => y.id == id).length > 0) {
        booksWrittenByAuthor.push(x);
      }
    });

    return booksWrittenByAuthor;
  }

  insertBook(
    title: String,
    description: String,
    imageSrc: String,
    releaseDate: Date,
    authorIds: Array<string>,
    genreIds: Array<string>,
    languageIds: Array<string>,
    bookPrice: number
  ) {
    const headers = {
      Authorization: `Bearer ${this._userService.getUserToken()}`,
    };
    this._http
      .post<any>(
        'http://localhost:5000/api/book',
        {
          Title: title,
          Description: description,
          ImageSrc: imageSrc,
          ReleaseDate: releaseDate,
          GenreIds: genreIds,
          AuthorIds: authorIds,
          LanguageIds: languageIds,
          Price: bookPrice,
        },
        { headers }
      )
      .pipe(
        catchError((error: any, caught: Observable<any>): Observable<any> => {
          if(error.status = 422){
            let errors = error.error.errors as Array<IValidationError>
            this._errorModalService.setErrors(errors.map(x=>x.ErrorMessage));
          }else{
            this._errorModalService.setErrors([error.error.message])
          }

          return of();
        })
      )
      .subscribe({
        next: (data) => {
          this.getBooks();
        },
      });
  }

  editBook(book: BookDTO) {
    let languageIds: Number[] = [];
    book.Languages.forEach((x) => languageIds.push(x.id));
    let genreIds: Number[] = [];
    book.Genres.forEach((x) => genreIds.push(x.id));
    let authorIds: Number[] = [];
    book.Languages.forEach((x) => authorIds.push(x.id));

    const headers = {
      Authorization: `Bearer ${this._userService.getUserToken()}`,
    };
    this._http
      .put<any>(
        `http://localhost:5000/api/book/${book.id}`,
        {
          Title: book.Title,
          Description: book.Description,
          ImageSrc: book.ImageSrc,
          ReleaseDate: book.ReleaseDate,
          GenreIds: genreIds,
          AuthorIds: authorIds,
          LanguageIds: languageIds,
          Price: book.Prices[0].price,
        },
        { headers }
      )
      .pipe(
        catchError((error: any, caught: Observable<any>): Observable<any> => {
          if(error.status = 422){
            let errors = error.error.errors as Array<IValidationError>
            this._errorModalService.setErrors(errors.map(x=>x.ErrorMessage));
          }else{
            this._errorModalService.setErrors([error.error.message])
          }

          return of();
        })
      )
      .subscribe({
        next: (data) => {
          this.getBooks();
        },
      });
  }

  deleteBook(id: number) {
    const headers = {
      Authorization: `Bearer ${this._userService.getUserToken()}`,
    };
    this._http
      .delete<any>(`http://localhost:5000/api/book/${id}`, { headers })
      .pipe(
        catchError((error: any, caught: Observable<any>): Observable<any> => {
          this._errorModalService.setErrors([error.error.message]);

          return of();
        })
      )
      .subscribe({
        next: (data) => {
          this.getBooks();
        },
      });
  }
}
