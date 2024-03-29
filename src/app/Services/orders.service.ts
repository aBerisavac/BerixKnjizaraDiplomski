import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UsersService } from './users.service';
import { ErrorModalService } from './error-modal.service';
import { BehaviorSubject, Observable, catchError, of } from 'rxjs';
import { OrderDTO } from 'src/tsBusinessLayer/dtos/OrderDTO';
import { capitalizePropertyNamesWithoutIdCapitalization } from 'common';
import { OrderInvoiceDTO } from 'src/tsBusinessLayer/dtos/OrderInvoiceDTO';
import { BooksService } from './books.service';
import { UserDTO } from 'src/tsBusinessLayer/dtos/UserDTO';
import { IValidationError } from 'src/tsBusinessLayer/interfaces/IValidationError';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  constructor(
    private _http: HttpClient,
    private _userService: UsersService,
    private _booksService: BooksService,
    private _errorModalService: ErrorModalService
  ) {}

  private orders = new BehaviorSubject<Array<OrderDTO>>([]);
  public orders$ = this.orders.asObservable()

  getOrder(id: number){
    return this.orders.value.filter(x=>x.id==id)[0];
  }

  getOrders(){
    
    const headers = {
      Authorization: `Bearer ${this._userService.getUserToken()}`,
    };

    this._http
      .get<any>('http://localhost:5000/api/order', {headers})
      .pipe(
        catchError((error: any, caught: Observable<any>): Observable<any> => {
          this._errorModalService.setErrors([error.error.message]);

          return of();
        })
      )
      .subscribe({
        next: (data) => {
          let ordersFromBack = [];
          for (let order of data) {
            ordersFromBack.push(
              capitalizePropertyNamesWithoutIdCapitalization(
                order
              )
            );
          }

          let orderInvoicesFromBack: OrderInvoiceDTO[] = [];
          for(let order of ordersFromBack){
            order["Customer"] = capitalizePropertyNamesWithoutIdCapitalization(order["Customer"])
            order["ShippingMethod"] = capitalizePropertyNamesWithoutIdCapitalization(order["ShippingMethod"])
            for(let orderInvoice of order["OrderInvoices"]){
              let book = this._booksService.getBook(orderInvoice["bookId"])
              orderInvoice = capitalizePropertyNamesWithoutIdCapitalization(orderInvoice)
              orderInvoice["Book"]=book;
              orderInvoicesFromBack.push(orderInvoice as OrderInvoiceDTO);
            }
            order["OrderInvoices"]=orderInvoicesFromBack;
            orderInvoicesFromBack = [];
          }
          this.orders.next(ordersFromBack as OrderDTO[]);
        },
      });
  }

  getAuthor(id: number): OrderDTO {
    return this.orders.getValue().filter((x) => x.id == id)[0];
  }

  insertOrder(order: OrderDTO){
    let orderInvoicesForBack = []
    for(let orderInvoiceDTO of order.OrderInvoices){
      orderInvoicesForBack.push({
        "BookId": orderInvoiceDTO.Book.id,
        "NumberOfItems": orderInvoiceDTO.NumberOfItems
      })
    }

    const headers = {
      Authorization: `Bearer ${this._userService.getUserToken()}`,
    };

    this._http
      .post<any>(
        'http://localhost:5000/api/order',
        {CustomerId: order.Customer.id, ShippingAddress: order.ShippingAddress, ShippingMethodId: order.ShippingMethod.id, OrderInvoices: orderInvoicesForBack },
        { headers }
      )
      .pipe(
        catchError((error: any, caught: Observable<any>): Observable<any> => {
          if(error.status = 422){
            let errors = error.error.errors as Array<IValidationError>
            this._errorModalService.setErrors(errors.map(x=>x.ErrorMessage));
          }else{
            this._errorModalService.setErrors([error.error.message])
          }

          return of();
        })
      )
      .subscribe({
        next: (data) => {
          this.getOrders();
        },
      });
  }
}
