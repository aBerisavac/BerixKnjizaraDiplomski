import { IOrderInvoice } from '../interfaces/IOrderInvoice';
import { BookDTO } from './BookDTO';

export class OrderInvoiceDTO implements IOrderInvoice {
  public id: number;
  public Book: BookDTO;
  public NumberOfItems: number;
  public PricePerItem?: number;

  constructor(
    id: number,
    book: BookDTO,
    NumberOfItems: number,
    PricePerItem?: number
  ) {
    this.id = id;
    this.Book = book;
    this.NumberOfItems = NumberOfItems;
    if (PricePerItem) {
      this.PricePerItem = PricePerItem;
    }
  }
}
