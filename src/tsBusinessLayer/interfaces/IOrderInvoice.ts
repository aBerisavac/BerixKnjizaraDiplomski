import { IBook } from "./IBook";

export interface IOrderInvoice{
    "id": number,
    "Book": IBook,
    "NumberOfBooks": number
}