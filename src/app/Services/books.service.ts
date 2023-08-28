import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthorModel } from 'src/tsBusinessLayer/Models/AuthorModel';
import { BookModel } from 'src/tsBusinessLayer/Models/BookModel';
import { BookPriceModel } from 'src/tsBusinessLayer/Models/BookPriceModel';
import { GenreModel } from 'src/tsBusinessLayer/Models/GenreModel';
import { LanguageModel } from 'src/tsBusinessLayer/Models/LanguageModel';
import { OrderModel } from 'src/tsBusinessLayer/Models/OrderModel';
import { AuthorDTO } from 'src/tsBusinessLayer/dtos/AuthorDTO';
import { BookDTO } from 'src/tsBusinessLayer/dtos/BookDTO';
import { BookPriceDTO } from 'src/tsBusinessLayer/dtos/BookPriceDTO';
import { GenreDTO } from 'src/tsBusinessLayer/dtos/GenreDTO';
import { LanguageDTO } from 'src/tsBusinessLayer/dtos/LanguageDTO';
import { OrderDTO } from 'src/tsBusinessLayer/dtos/OrderDTO';

@Injectable({
  providedIn: 'root'
})
export class BooksService {

  constructor(private _http: HttpClient) { }

  private ordersModel = new OrderModel(this._http);
  private bookModel = new BookModel();
  private authorModel = new AuthorModel();
  private genreModel = new GenreModel();
  private languageModel = new LanguageModel();
  private bookPriceModel = new BookPriceModel();

  getBooks() : BookDTO[]{
    return this.bookModel.getAll();
  }

  getBook(id: number) : BookDTO{
    return this.bookModel.get(id);
  }

  insertBook(title: String, description: String, imageSrc: String, releaseDate: Date, authorIds:Array<string>, genreIds:Array<string>, languageIds:Array<string>, bookPrice:number): boolean{
    try{
      
      let authors: Array<AuthorDTO>= [];
      for(let id of authorIds){
        authors.push(this.authorModel.get(parseInt(id)))
      }

      let genres: Array<GenreDTO>= [];
      for(let id of genreIds){
        genres.push(this.genreModel.get(parseInt(id)))
      }

      let languages: Array<LanguageDTO>= [];
      for(let id of languageIds){
        languages.push(this.languageModel.get(parseInt(id)))
      }

      this.bookPriceModel.insertBookPrice(bookPrice)

      let bookPrices: Array<BookPriceDTO> = [this.bookPriceModel.getAll()[this.bookPriceModel.getAll().length - 1] as BookPriceDTO]
    
      this.bookModel.insertBook(title, description, imageSrc, releaseDate, authors, genres, languages, bookPrices)
      return true;
    } catch(ex){
      return false;
    }
  }

  deleteBook(id: number): String[]{
    let errors = [];
    let orders = this.ordersModel.getAll() as Array<OrderDTO>;
    for (let order of orders) {
      if (order.OrderInvoices.filter(x=>x.Book.id==id).length>0) {
        errors.push('Referential integrity violation. This book exists in some of the orders.');
        break;
      }
    }

    if (errors.length == 0) {
      this.bookModel.deleteItem(id);
    }

    return errors;
  }
}
