import { IOrderInvoice } from "./IOrderInvoice";
import { IShippingMethod } from "./IShippingMethod";
import { IUser } from "./IUser";

export interface IOrder {
    "id": number,
    "Customer": IUser,
    "ShippingMethod": IShippingMethod,
    "OrderInvoices": Array<IOrderInvoice>
}