import { Injectable } from '@angular/core';
import { AuthorDTO } from 'src/tsBusinessLayer/dtos/AuthorDTO';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, catchError, of } from 'rxjs';
import { capitalizePropertyNamesWithoutIdCapitalization } from 'common';
import { UsersService } from './users.service';
import { ErrorModalService } from './error-modal.service';
import { IValidationError } from 'src/tsBusinessLayer/interfaces/IValidationError';

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

  getAuthors(){
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
          this.getAuthors();
        },
      });
  }

  updateAuthor(author: AuthorDTO){
    const headers = {
      Authorization: `Bearer ${this._userService.getUserToken()}`,
    };
    this._http
      .put<any>(
        `http://localhost:5000/api/author/${author.id}`,
        { FirstName: author.FirstName, LastName: author.LastName, BirthDate: author.BirthDate },
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
