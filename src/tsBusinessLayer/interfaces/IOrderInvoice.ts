import { IBook } from "./IBook";

export interface IOrderInvoice{
    "id": number,
    "Book": IBook,
    "NumberOfItems": number
    "PricePerItem"?: number
}