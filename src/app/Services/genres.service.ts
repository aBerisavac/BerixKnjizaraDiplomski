import { Injectable } from '@angular/core';
import { BookModel } from 'src/tsBusinessLayer/Models/BookModel';
import { GenreModel } from 'src/tsBusinessLayer/Models/GenreModel';
import { BookDTO } from 'src/tsBusinessLayer/dtos/BookDTO';
import { GenreDTO } from 'src/tsBusinessLayer/dtos/GenreDTO';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, catchError, of } from 'rxjs';
import { capitalizePropertyNamesWithoutIdCapitalization } from 'common';

@Injectable({
  providedIn: 'root'
})
export class GenresService {

  constructor(private _http: HttpClient) { }

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

  insertGenre(name: String): boolean{
    try{
      this.genreModel.insertGenre(name)
      return true;
    } catch(ex){
      return false;
    }
  }

  deleteGenre(id: number): String[] {
    let errors = [];
    let books = this.bookModel.getAll() as Array<BookDTO>;
    for (let book of books) {
      if (book.Genres.filter((x) => x.id == id).length > 0) {
        errors.push('Referential integrity violation.');
        break;
      }
    }

    if (errors.length == 0) {
      this.genreModel.deleteItem(id);
    }

    return errors;
  }
}
