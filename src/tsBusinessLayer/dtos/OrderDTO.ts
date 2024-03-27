import {IOrder} from "../interfaces/IOrder"
import { OrderInvoiceDTO } from "./OrderInvoiceDTO";
import { ShippingMethodDTO } from "./ShippingMethodDTO";
import { UserDTO } from "./UserDTO";

export class OrderDTO implements IOrder{
    public id:number;
    public Customer: UserDTO;
    public ShippingMethod:ShippingMethodDTO;
    public OrderInvoices:Array<OrderInvoiceDTO>;
    public ShippingAddress?:string;

    constructor(id:number, customer: UserDTO, shippingMethod: ShippingMethodDTO, orderInvoices:Array<OrderInvoiceDTO>, ShippingAddress?:string){
        this.id = id;
        this.Customer = customer;
        this.ShippingMethod = shippingMethod;
        this.OrderInvoices = orderInvoices;
        if(ShippingAddress){
            this.ShippingAddress = ShippingAddress;
        }
    }
}