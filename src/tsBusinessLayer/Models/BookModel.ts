declare var require: any;

import { BookDTO } from '../dtos/BookDTO';
import { IEntityGet } from '../interfaces/common/IEntityGet';
import { IEntityGetAll } from '../interfaces/common/IEntityGetAll';
import { AuthorModel } from './AuthorModel';
import { BookPriceModel } from './BookPriceModel';
import { GenreModel } from './GenreModel';
import { TBookJSON } from '../types/JSON/TBookJson';
import { LanguageModel } from './LanguageModel';
import { BookPriceDTO } from '../dtos/BookPriceDTO';
import { AuthorDTO } from '../dtos/AuthorDTO';
import { GenreDTO } from '../dtos/GenreDTO';
import { LanguageDTO } from '../dtos/LanguageDTO';

export class BookModel implements IEntityGetAll, IEntityGet {
  private books: Array<BookDTO> = [];

  constructor() {
    if (localStorage.getItem('Books') == undefined) {
      let books: Array<TBookJSON> = require('src/assets/data/book.json');
      this.books = this.convertBookFromJsonToDTO(books);
      localStorage.setItem('Books', JSON.stringify(this.books));
    } else {
      this.books = JSON.parse(localStorage.getItem('Books')!);
    }
  }

  public getAll<BookDTO>(): Array<BookDTO> {
    return this.books as Array<BookDTO>;
  }

  private getMaxId(){
    let maxId = this.books.sort((x,y)=>y.id-x.id)[0].id;
    this.books.sort((x,y)=>x.id-y.id)[0].id
    return maxId;
  }

  public get<BookDTO>(id: number): BookDTO {
    return this.books.filter((x) => x.id == id)[0] as BookDTO;
  }

  public insertBook(title: String, description: String, imageSrc: String, releaseDate: Date, authors:Array<AuthorDTO>, genres:Array<GenreDTO>, languages:Array<LanguageDTO>, bookPrices:Array<BookPriceDTO>){
    this.books.push(new BookDTO(this.getMaxId()+1, title, description, imageSrc, releaseDate, authors, genres, languages, bookPrices))

    localStorage.setItem(
      'Books',
      JSON.stringify(this.books)
    );
  }

  public deleteItem(id: number) {
    let helpingArray: Array<BookDTO> = [];
    for (let book of this.books) {
      if (book.id != id) {
        helpingArray.push(book);
      }
    }

    this.books = helpingArray;

    localStorage.setItem('Books', JSON.stringify(this.books));
  }

  private convertBookFromJsonToDTO(books: Array<TBookJSON>): Array<BookDTO> {
    let booksDTO: Array<BookDTO> = [];

    let genreModel = new GenreModel();
    let authorModel = new AuthorModel();
    let bookPriceModel = new BookPriceModel();
    let languageModel = new LanguageModel();

    for (let book of books) {
      booksDTO.push({
        id: book.id,
        Title: book.Title,
        Description: book.Description,
        ImageSrc: book.ImageSrc,
        ReleaseDate: new Date(`${book.ReleaseDate}`),
        Authors: authorModel.getAuthorsByBook(book),
        Genres: genreModel.getGenresByBook(book),
        BookPrices: bookPriceModel.getBookPricesByBook(book),
        Languages: languageModel.getLanguagesByBook(book),
      });
    }

    return booksDTO;
  }
}
