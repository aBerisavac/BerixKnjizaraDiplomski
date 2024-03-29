import { Injectable } from '@angular/core';
import { GenreDTO } from 'src/tsBusinessLayer/dtos/GenreDTO';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, catchError, of } from 'rxjs';
import { capitalizePropertyNamesWithoutIdCapitalization } from 'common';
import { ErrorModalService } from './error-modal.service';
import { UsersService } from './users.service';
import { IValidationError } from 'src/tsBusinessLayer/interfaces/IValidationError';

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

  getGenres() {
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
  }

  getGenre(id: number): GenreDTO {
    return this.genres.getValue().filter((x) => x.id == id)[0];
  }

  insertGenre(name: String){
    const headers = { 'Authorization': `Bearer ${this._userService.getUserToken()}` };
    this._http
    .post<any>('http://localhost:5000/api/genre', {Name: name}, {headers})
    .pipe(catchError((error: any, caught: Observable<any>): Observable<any> => {
      if(error.status = 422){
        let errors = error.error.errors as Array<IValidationError>
        this._errorModalService.setErrors(errors.map(x=>x.ErrorMessage));
      }else{
        this._errorModalService.setErrors([error.error.message])
      }

      return of();
  }))
    .subscribe({
      next: (data) => {
        this.getGenres();
      }
    });
  }

  editGenre(genre:GenreDTO){
    const headers = { 'Authorization': `Bearer ${this._userService.getUserToken()}` };
    this._http
    .put<any>(`http://localhost:5000/api/genre/${genre.id}`, {Name: genre.Name}, {headers})
    .pipe(catchError((error: any, caught: Observable<any>): Observable<any> => {
      if(error.status = 422){
        let errors = error.error.errors as Array<IValidationError>
        this._errorModalService.setErrors(errors.map(x=>x.ErrorMessage));
      }else{
        this._errorModalService.setErrors([error.error.message])
      }

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
