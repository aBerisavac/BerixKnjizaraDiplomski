import { Injectable } from '@angular/core';
import { BookModel } from 'src/tsBusinessLayer/Models/BookModel';
import { GenreModel } from 'src/tsBusinessLayer/Models/GenreModel';
import { BookDTO } from 'src/tsBusinessLayer/dtos/BookDTO';
import { GenreDTO } from 'src/tsBusinessLayer/dtos/GenreDTO';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, catchError, of } from 'rxjs';
import { capitalizePropertyNamesWithoutIdCapitalization } from 'common';
import { ErrorModalService } from './error-modal.service';
import { UsersService } from './users.service';

@Injectable({
  providedIn: 'root'
})
export class GenresService {

  constructor(
    private _errorModalService: ErrorModalService, 
    private _userService: UsersService, 
    private _http: HttpClient,) { }

  private genres = new BehaviorSubject<Array<GenreDTO>>([]);
  public genres$ = this.genres.asObservable();

  private genreModel = new GenreModel();
  private bookModel = new BookModel();

  getGenres(): GenreDTO[] {
    this._http
    .get<any>('http://localhost:5000/api/genre')
    .pipe(catchError((error: any, caught: Observable<any>): Observable<any> => {
      console.log(error)

      return of();
  }))
    .subscribe({
      next: (data) => {
        let genresFromBack: GenreDTO[] = [];
        for(let genre of data){
          genresFromBack.push(capitalizePropertyNamesWithoutIdCapitalization(genre) as GenreDTO);
        }
        this.genres.next(genresFromBack);
      }
    });

    return this.genreModel.getAll();
  }

  getGenre(id: number): GenreDTO {
    return this.genreModel.get(id);
  }

  insertGenre(name: String){
    const headers = { 'Authorization': `Bearer ${this._userService.getUserToken()}` };
    this._http
    .post<any>('http://localhost:5000/api/genre', {Name: name}, {headers})
    .pipe(catchError((error: any, caught: Observable<any>): Observable<any> => {
      console.log(error)
      this._errorModalService.setErrors([error.error.message])

      return of();
  }))
    .subscribe({
      next: (data) => {
        this.getGenres();
      }
    });
  }

  deleteGenre(id: number) {
    const headers = { 'Authorization': `Bearer ${this._userService.getUserToken()}`};
    this._http
    .delete<any>(`http://localhost:5000/api/genre/${id}`, {headers})
    .pipe(catchError((error: any, caught: Observable<any>): Observable<any> => {
      this._errorModalService.setErrors([error.error.message])

      return of();
  }))
    .subscribe({
      next: (data) => {
        this.getGenres();
      }
    });
  }
}
