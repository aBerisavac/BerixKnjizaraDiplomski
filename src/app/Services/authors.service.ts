import { Injectable } from '@angular/core';
import { AuthorModel } from 'src/tsBusinessLayer/Models/AuthorModel';
import { BookModel } from 'src/tsBusinessLayer/Models/BookModel';
import { AuthorDTO } from 'src/tsBusinessLayer/dtos/AuthorDTO';
import { BookDTO } from 'src/tsBusinessLayer/dtos/BookDTO';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, catchError, of } from 'rxjs';
import { capitalizePropertyNamesWithoutIdCapitalization } from 'common';
import { UsersService } from './users.service';
import { BooksService } from './books.service';
import { ErrorModalService } from './error-modal.service';

@Injectable({
  providedIn: 'root',
})
export class AuthorsService {
  constructor(
    private _http: HttpClient,
    private _userService: UsersService,
    private _errorModalService: ErrorModalService
  ) {}

  private authors = new BehaviorSubject<Array<AuthorDTO>>([]);
  public authors$ = this.authors.asObservable();

  private errors = new BehaviorSubject<Array<string>>([]);
  private errors$ = this.errors.asObservable();

  private bookModel = new BookModel();
  private authorModel = new AuthorModel();

  getAuthors(): AuthorDTO[] {
    this._http
      .get<any>('http://localhost:5000/api/author')
      .pipe(
        catchError((error: any, caught: Observable<any>): Observable<any> => {
          this._errorModalService.setErrors([error.error.message]);

          return of();
        })
      )
      .subscribe({
        next: (data) => {
          let authorsFromBack: AuthorDTO[] = [];
          for (let author of data) {
            authorsFromBack.push(
              capitalizePropertyNamesWithoutIdCapitalization(
                author
              ) as AuthorDTO
            );
          }
          this.authors.next(authorsFromBack);
        },
      });

    return this.authorModel.getAll();
  }

  getAuthor(id: number): AuthorDTO {
    return this.authors.getValue().filter((x) => x.id == id)[0];
  }

  insertAuthor(firstName: String, lastName: String, birthDate: Date) {
    const headers = {
      Authorization: `Bearer ${this._userService.getUserToken()}`,
    };
    this._http
      .post<any>(
        'http://localhost:5000/api/author',
        { FirstName: firstName, LastName: lastName, BirthDate: birthDate },
        { headers }
      )
      .pipe(
        catchError((error: any, caught: Observable<any>): Observable<any> => {
          console.log(error);
          this._errorModalService.setErrors([error.error.message]);

          return of();
        })
      )
      .subscribe({
        next: (data) => {
          this.getAuthors();
        },
      });
  }

  deleteAuthor(id: number) {
    const headers = {
      Authorization: `Bearer ${this._userService.getUserToken()}`,
    };
    this._http
      .delete<any>(`http://localhost:5000/api/author/${id}`, { headers })
      .pipe(
        catchError((error: any, caught: Observable<any>): Observable<any> => {
          this._errorModalService.setErrors([error.error.message]);

          return of();
        })
      )
      .subscribe({
        next: (data) => {
          this.getAuthors();
        },
      });
  }
}
