import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, catchError, of } from 'rxjs';
import { HomeParagraphDTO } from 'src/tsBusinessLayer/dtos/HomeParagraphDTO';
import { capitalizePropertyNamesWithoutIdCapitalization } from 'common';
import { UsersService } from './users.service';
import { ErrorModalService } from './error-modal.service';

@Injectable({
  providedIn: 'root',
})
export class HomeService {
  constructor(
    private _http: HttpClient,
    private _userService: UsersService,
    private _errorModalService: ErrorModalService
  ) {}

  private homeParagraphs = new BehaviorSubject<Array<HomeParagraphDTO>>([]);
  public homeParagraphs$ = this.homeParagraphs.asObservable();

  getHomeParagraphs() {
    this._http
      .get<any>('http://localhost:5000/api/home')
      .pipe(
        catchError((error: any, caught: Observable<any>): Observable<any> => {
          console.log(error);

          return of();
        })
      )
      .subscribe({
        next: (data) => {
          let homeParagraphsFromBack: HomeParagraphDTO[] = [];
          for (let homeParagraph of data) {
            homeParagraphsFromBack.push(
              capitalizePropertyNamesWithoutIdCapitalization(
                homeParagraph
              ) as HomeParagraphDTO
            );
          }
          this.homeParagraphs.next(homeParagraphsFromBack);
        },
      });
  }

  getHomeParagraph(id: number) {
    return this.homeParagraphs.getValue().filter((x) => x.id == id)[0];
  }

  insertHomeParagraph(homeParagraph: HomeParagraphDTO) {
    const headers = {
      Authorization: `Bearer ${this._userService.getUserToken()}`,
    };
    this._http
      .post<any>('http://localhost:5000/api/home', { Paragraph: homeParagraph.Paragraph }, { headers })
      .pipe(
        catchError((error: any, caught: Observable<any>): Observable<any> => {
          console.log(error);
          this._errorModalService.setErrors([error.error.message]);

          return of();
        })
      )
      .subscribe({
        next: (data) => {
          this.getHomeParagraphs();
        },
      });
  }

  editHomeParagraph(homeParagraph: HomeParagraphDTO) {
    const headers = { 'Authorization': `Bearer ${this._userService.getUserToken()}` };
    this._http
    .put<any>(`http://localhost:5000/api/home/${homeParagraph.id}`, {Paragraph: homeParagraph.Paragraph}, {headers})
    .pipe(catchError((error: any, caught: Observable<any>): Observable<any> => {
      this._errorModalService.setErrors([error.error.message])

      return of();
  }))
    .subscribe({
      next: (data) => {
        this.getHomeParagraphs();
      }
    });
  }

  deleteHomeParagraph(id: number) {
    const headers = { 'Authorization': `Bearer ${this._userService.getUserToken()}`};
    this._http
    .delete<any>(`http://localhost:5000/api/home/${id}`, {headers})
    .pipe(catchError((error: any, caught: Observable<any>): Observable<any> => {
      this._errorModalService.setErrors([error.error.message])

      return of();
  }))
    .subscribe({
      next: (data) => {
        this.getHomeParagraphs();
      }
    });
  }
}
