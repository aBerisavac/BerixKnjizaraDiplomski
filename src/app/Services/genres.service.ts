import { Injectable } from '@angular/core';
import { BookModel } from 'src/tsBusinessLayer/Models/BookModel';
import { GenreModel } from 'src/tsBusinessLayer/Models/GenreModel';
import { BookDTO } from 'src/tsBusinessLayer/dtos/BookDTO';
import { GenreDTO } from 'src/tsBusinessLayer/dtos/GenreDTO';

@Injectable({
  providedIn: 'root'
})
export class GenresService {

  constructor() { }

  private genreModel = new GenreModel();
  private bookModel = new BookModel();

  getGenres(): GenreDTO[] {
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
