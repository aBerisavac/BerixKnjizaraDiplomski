import {IOrderInvoice} from "../interfaces/IOrderInvoice"
import { BookDTO } from "./BookDTO";

export class OrderInvoiceDTO implements IOrderInvoice{
    public id:number;
    public Book:BookDTO;
    public NumberOfItems:number;

    constructor(id:number, book: BookDTO, NumberOfItems: number){
        this.id = id;
        this.Book = book;
        this.NumberOfItems = NumberOfItems;
    }
}