import { Injectable } from '@angular/core';
import { LanguageDTO } from 'src/tsBusinessLayer/dtos/LanguageDTO';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, catchError, of } from 'rxjs';
import { capitalizePropertyNamesWithoutIdCapitalization } from 'common';
import { UsersService } from './users.service';
import { ErrorModalService } from './error-modal.service';
import { IValidationError } from 'src/tsBusinessLayer/interfaces/IValidationError';

@Injectable({
  providedIn: 'root',
})
export class LanguagesService {
  constructor(
    private _http: HttpClient,
    private _userService: UsersService,
    private _errorModalService: ErrorModalService
  ) {}

  private languages = new BehaviorSubject<Array<LanguageDTO>>([]);
  public languages$ = this.languages.asObservable();

  getLanguages() {
    this._http
      .get<any>('http://localhost:5000/api/language')
      .pipe(
        catchError((error: any, caught: Observable<any>): Observable<any> => {
          console.log(error);

          return of();
        })
      )
      .subscribe({
        next: (data) => {
          let languagesFromBack: LanguageDTO[] = [];
          for (let language of data) {
            languagesFromBack.push(
              capitalizePropertyNamesWithoutIdCapitalization(
                language
              ) as LanguageDTO
            );
          }

          this.languages.next(languagesFromBack);
        },
      });
  }

  getLanguage(id: number): LanguageDTO {
    return this.languages.getValue().filter((x) => x.id == id)[0];
  }

  public insertLanguage(language: LanguageDTO) {
    const headers = {
      Authorization: `Bearer ${this._userService.getUserToken()}`,
    };
    this._http
      .post<any>(
        'http://localhost:5000/api/language',
        { Name: language.Name },
        { headers }
      )
      .pipe(
        catchError((error: any, caught: Observable<any>): Observable<any> => {
          if ((error.status = 422)) {
            let errors = error.error.errors as Array<IValidationError>;
            this._errorModalService.setErrors(
              errors.map((x) => x.ErrorMessage)
            );
          } else {
            this._errorModalService.setErrors([error.error.message]);
          }

          return of();
        })
      )
      .subscribe({
        next: (data) => {
          this.getLanguages();
        },
      });
  }

  public editLanguage(language: LanguageDTO) {
    const headers = {
      Authorization: `Bearer ${this._userService.getUserToken()}`,
    };
    this._http
      .put<any>(
        `http://localhost:5000/api/language/${language.id}`,
        { Name: language.Name },
        { headers }
      )
      .pipe(
        catchError((error: any, caught: Observable<any>): Observable<any> => {
          if ((error.status = 422)) {
            let errors = error.error.errors as Array<IValidationError>;
            this._errorModalService.setErrors(
              errors.map((x) => x.ErrorMessage)
            );
          } else {
            this._errorModalService.setErrors([error.error.message]);
          }

          return of();
        })
      )
      .subscribe({
        next: (data) => {
          this.getLanguages();
        },
      });
  }

  public deleteLanguage(id: number) {
    const headers = {
      Authorization: `Bearer ${this._userService.getUserToken()}`,
    };
    this._http
      .delete<any>(`http://localhost:5000/api/language/${id}`, { headers })
      .pipe(
        catchError((error: any, caught: Observable<any>): Observable<any> => {
          this._errorModalService.setErrors([error.error.message]);

          return of();
        })
      )
      .subscribe({
        next: (data) => {
          this.getLanguages();
        },
      });
  }
}
