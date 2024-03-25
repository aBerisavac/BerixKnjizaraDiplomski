import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IOrderAdmin } from 'src/app/Interfaces/IOrderAdmin';
import { BooksService } from 'src/app/Services/books.service';
import { OrdersService } from 'src/app/Services/orders.service';
import { OrderDTO } from 'src/tsBusinessLayer/dtos/OrderDTO';

@Component({
  selector: 'app-admin-orders',
  templateUrl: './admin-orders.component.html',
  styleUrls: ['./admin-orders.component.scss']
})
export class AdminOrdersComponent implements OnInit{
  public jsonObjectArrayToDisplay: Array<IOrderAdmin> = [];

  constructor(
    private _ordersService: OrdersService,
    private _booksService: BooksService,
    ){
      _booksService.getBooks();
      _booksService.books$.subscribe(x=>{
        if(x.length>0){
          _ordersService.getOrders()
        }
      })
  }
  ngOnInit(): void {
    this._ordersService.orders$.subscribe(x=>{
      this.convertOrderDTOTOIOrderAdmin(x)
    });
  }

  convertOrderDTOTOIOrderAdmin(orders: OrderDTO[]){
    this.jsonObjectArrayToDisplay = [];
    for(let order of orders){
      let price = 0;
      order.OrderInvoices.forEach(x=>price+= x.NumberOfItems*x.Book.Prices[0].price)
      let orderAdmin = {
        "id": order.id,
        "Customer name": order.Customer.FirstName+" "+order.Customer.LastName,
        "Customer email": order.Customer.Email,
        "Customer address": order.Customer.Address,
        "Shipping method": order.ShippingMethod.Name,
        // "Price": order.ShippingMethod.Cost + price,
        "Price (shipping)": price + order.ShippingMethod.Cost + "$" + (" (" + order.ShippingMethod.Cost+"$)"),
      } as IOrderAdmin;

      this.jsonObjectArrayToDisplay.push(orderAdmin);
    }
  }
  editItem(item: IOrderAdmin){
    console.log(item)
  }

  deleteItem(item: IOrderAdmin){
    console.log(item)
  }
}
