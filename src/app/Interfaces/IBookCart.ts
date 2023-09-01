import { IBook } from "src/tsBusinessLayer/interfaces/IBook"

export interface IBookCart extends IBook{
    "Quantity": number,
    "Price": number
}