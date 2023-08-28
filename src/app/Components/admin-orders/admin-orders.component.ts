import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { IOrderAdmin } from 'src/app/Interfaces/IOrderAdmin';
import { OrderModel } from 'src/tsBusinessLayer/Models/OrderModel';
import { OrderDTO } from 'src/tsBusinessLayer/dtos/OrderDTO';

@Component({
  selector: 'app-admin-orders',
  templateUrl: './admin-orders.component.html',
  styleUrls: ['./admin-orders.component.scss']
})
export class AdminOrdersComponent{
  private ordersModel: OrderModel;
  private orders: Array<OrderDTO>;
  public jsonObjectArrayToDisplay: Array<IOrderAdmin> = [];

  constructor(private _http: HttpClient){
    this.ordersModel = new OrderModel(this._http);
    this.orders = this.ordersModel.getAll() as Array<OrderDTO>;
    for(let order of this.orders){
      let price = 0;
      order.OrderInvoices.forEach(x=>price+= x.NumberOfBooks*x.Book.BookPrices[0].Price)
      let orderAdmin = {
        "id": order.id,
        "Customer name": order.Customer.FirstName+" "+order.Customer.LastName,
        "Customer email": order.Customer.Email,
        "Customer address": order.Customer.Address,
        "Shipping method": order.ShippingMethod.Name,
        "Price": order.ShippingMethod.Cost + price,
      } as IOrderAdmin;

      this.jsonObjectArrayToDisplay.push(orderAdmin);
    }

    this.jsonObjectArrayToDisplay.sort((x, y)=> x.id-y.id)
  }

  editItem(item: IOrderAdmin){
    console.log(item)
  }

  deleteItem(item: IOrderAdmin){
    console.log(item)
  }
}
