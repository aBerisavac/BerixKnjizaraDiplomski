import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { IOrderAdmin } from 'src/app/Interfaces/IOrderAdmin';
import { BooksService } from 'src/app/Services/books.service';
import { OrdersService } from 'src/app/Services/orders.service';
import { OrderDTO } from 'src/tsBusinessLayer/dtos/OrderDTO';

@Component({
  selector: 'app-admin-orders',
  templateUrl: './admin-orders.component.html',
  styleUrls: ['./admin-orders.component.scss'],
})
export class AdminOrdersComponent implements OnInit {
  public jsonObjectArrayToDisplay: Array<IOrderAdmin> = [];
  public showOrderDetailsBool: boolean = false;
  public selectedOrder: OrderDTO | undefined = undefined;

  constructor(
    private _ordersService: OrdersService,
    private _booksService: BooksService
  ) {
    _booksService.getBooks();
    _booksService.books$.subscribe((x) => {
      if (x.length > 0) {
        _ordersService.getOrders();
      }
    });
  }
  ngOnInit(): void {
    this._ordersService.orders$.subscribe((x) => {
      this.convertOrderDTOTOIOrderAdmin(x);
    });
  }

  convertOrderDTOTOIOrderAdmin(orders: OrderDTO[]) {
    this.jsonObjectArrayToDisplay = [];
    orders.sort((x, y) => {
      const dateX = new Date(x.CreatedAt!);
      const dateY = new Date(y.CreatedAt!);
      return dateY.getTime() - dateX.getTime();
    });
    for (let order of orders) {
      let price = 0;
      order.OrderInvoices.forEach(
        (x) => (price += x.NumberOfItems * x.PricePerItem!)
      );
      let orderAdmin = {
        id: order.id,
        'Customer name':
          order.Customer.FirstName + ' ' + order.Customer.LastName,
        'Customer email': order.Customer.Email,
        'Customer address': order.ShippingAddress,
        'Shipping method': `${order.ShippingMethod.Name} (${order.ShippingMethodPrice}$)`,
        'Date': formatDate(order.CreatedAt!, 'MMM d, y, hh:mm', 'en'),
        // "Price": order.ShippingMethod.Cost + price,
        'Price (with shipping)':
          price +
          order.ShippingMethodPrice! +
          '$',
      } as IOrderAdmin;

      this.jsonObjectArrayToDisplay.push(orderAdmin);
    }
  }

  showOrderDetails(item: IOrderAdmin) {
    this.selectedOrder = this._ordersService.getOrder(item.id);
    this.showOrderDetailsBool = true;
  }

  closeOrderDetails() {
    this.showOrderDetailsBool = false;
  }

  editItem(item: IOrderAdmin) {
    console.log(item);
  }

  deleteItem(item: IOrderAdmin) {
    console.log(item);
  }
}
