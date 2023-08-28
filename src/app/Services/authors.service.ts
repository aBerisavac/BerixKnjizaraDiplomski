import { Injectable } from '@angular/core';
import { AuthorModel } from 'src/tsBusinessLayer/Models/AuthorModel';
import { BookModel } from 'src/tsBusinessLayer/Models/BookModel';
import { AuthorDTO } from 'src/tsBusinessLayer/dtos/AuthorDTO';
import { BookDTO } from 'src/tsBusinessLayer/dtos/BookDTO';

@Injectable({
  providedIn: 'root',
})
export class AuthorsService {
  constructor() {}

  private authorModel = new AuthorModel();
  private bookModel = new BookModel();

  getAuthors(): AuthorDTO[] {
    return this.authorModel.getAll();
  }

  getAuthor(id: number): AuthorDTO {
    return this.authorModel.get(id);
  }

  private capitalizePropertyNames(obj: any) {
    const newObj: { [key: string]: any } = {};

    for (let key in obj) {
        const capitalizedKey = key.charAt(0).toUpperCase() + key.slice(1);
        newObj[capitalizedKey] = obj[key];
    }

    return newObj;
  }

  getBooksWrittenByAuthor(author: AuthorDTO): Array<BookDTO> {
    let books: Array<BookDTO> = this.bookModel.getAll();
    let booksWithRequestedAutor: Array<BookDTO> = [];

    for (let book of books) {
      for (let bookAuthor of book.Authors) {
        if (bookAuthor.id == author.id) {
          booksWithRequestedAutor.push(book);
          break;
        }
      }
    }

    return booksWithRequestedAutor;
  }

  insertAuthor(firstName: String, lastName: String, birthDate: Date, ): boolean{
    try{
      this.authorModel.insertAuthor(firstName, lastName, birthDate)
      return true;
    } catch(ex){
      return false;
    }
  }

  deleteAuthor(id: number): String[] {
    let errors = [];
    let books = this.bookModel.getAll() as Array<BookDTO>;
    for (let book of books) {
      if (book.Authors.filter((x) => x.id == id).length > 0) {
        errors.push('Referential integrity violation.');
        break;
      }
    }

    if (errors.length == 0) {
      this.authorModel.deleteItem(id);
    }

    return errors;
  }
}
