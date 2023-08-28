import { IBookCart } from "src/app/Interfaces/IBookCart";
import { ShippingMethodDTO } from "../dtos/ShippingMethodDTO";

export interface IAddOrder {
    "FirstName": String,
    "LastName": String,
    "Email": String,
    "Address": String,
    "Password": String,
    "ShippingMethod": ShippingMethodDTO,
    "items": Array<IBookCart>,
}