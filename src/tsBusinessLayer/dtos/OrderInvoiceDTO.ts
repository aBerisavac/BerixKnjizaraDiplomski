import {IOrderInvoice} from "../interfaces/IOrderInvoice"
import { BookDTO } from "./BookDTO";

export class OrderInvoiceDTO implements IOrderInvoice{
    public id:number;
    public Book:BookDTO;
    public NumberOfBooks:number;

    constructor(id:number, book: BookDTO, numberOfBooks: number){
        this.id = id;
        this.Book = book;
        this.NumberOfBooks = numberOfBooks;
    }
}