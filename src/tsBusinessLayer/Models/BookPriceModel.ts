declare var require: any;

import { BookPriceDTO } from '../dtos/BookPriceDTO';
import { IEntityGet } from '../interfaces/common/IEntityGet';
import { IEntityGetAll } from '../interfaces/common/IEntityGetAll';
import { TBookJSON } from '../types/JSON/TBookJson';
import { TBookPriceJson } from '../types/JSON/TBookPriceJson';

export class BookPriceModel implements IEntityGetAll, IEntityGet {
  private bookPrices: Array<BookPriceDTO> = [];

  constructor() {
    if (localStorage.getItem('BookPrices') == undefined) {
      let bookPrices: Array<TBookPriceJson> = require('src/assets/data/bookPrice.json');
      this.bookPrices = this.convertAuthorFromJsonToDTO(bookPrices);
      localStorage.setItem('BookPrices', JSON.stringify(this.bookPrices));
    } else {
      this.bookPrices = JSON.parse(localStorage.getItem('BookPrices')!);
    }
  }

  public getAll<BookPriceDTO>(): Array<BookPriceDTO> {
    return this.bookPrices as Array<BookPriceDTO>;
  }

  private getMaxId(){
    let maxId = this.bookPrices.sort((x,y)=>y.id-x.id)[0].id;
    this.bookPrices.sort((x,y)=>x.id-y.id)[0].id
    return maxId;
  }
  
  public insertBookPrice(price: number){
    this.bookPrices.push(new BookPriceDTO(this.getMaxId()+1, price))

    localStorage.setItem(
      'BookPrices',
      JSON.stringify(this.bookPrices)
    );
  }

  public get<BookPriceDTO>(id: number): BookPriceDTO {
    BookPriceDTO;
    return this.bookPrices.filter((x) => x.id == id)[0] as BookPriceDTO;
  }

  public getBookPricesByBook(book: TBookJSON): Array<BookPriceDTO> {
    let bookPriceIdsArray = book.BookPrices;

    let bookPrices: Array<BookPriceDTO> = [];
    for (let bookPriceId of bookPriceIdsArray) {
      bookPrices.push(this.get(bookPriceId));
    }
    return bookPrices;
  }

  

  private convertAuthorFromJsonToDTO(
    bookPrices: Array<TBookPriceJson>
  ): Array<BookPriceDTO> {
    let bookPricesDTO: Array<BookPriceDTO> = [];
    for (let bookPrice of bookPrices) {
      bookPricesDTO.push({
        id: bookPrice.id,
        price: bookPrice.Price,
      });
    }

    return bookPricesDTO;
  }
}
