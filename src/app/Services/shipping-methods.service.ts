import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { capitalizePropertyNamesWithoutIdCapitalization } from 'common';
import { BehaviorSubject, Observable, catchError, of } from 'rxjs';
import { OrderModel } from 'src/tsBusinessLayer/Models/OrderModel';
import { ShippingMethodModel } from 'src/tsBusinessLayer/Models/ShippingMethodModel';
import { OrderDTO } from 'src/tsBusinessLayer/dtos/OrderDTO';
import { ShippingMethodDTO } from 'src/tsBusinessLayer/dtos/ShippingMethodDTO';

@Injectable({
  providedIn: 'root',
})
export class ShippingMethodsService {
  constructor(private _http: HttpClient) {}

  
  private shippingMethods = new BehaviorSubject<Array<ShippingMethodDTO>>([]);
  public shippingMethods$ = this.shippingMethods.asObservable();

  private ordersModel: OrderModel = new OrderModel(this._http);
  private shippingMethodModel = new ShippingMethodModel();

  getShippingMethods(): ShippingMethodDTO[] {
    this._http
    .get<any>('http://localhost:5000/api/shippingMethod')
    .pipe(catchError((error: any, caught: Observable<any>): Observable<any> => {
      console.log(error)

      return of();
  }))
    .subscribe({
      next: (data) => {
        let shippingMethodsFromBack: ShippingMethodDTO[] = [];
        for(let shippingMethod of data){
          shippingMethodsFromBack.push(capitalizePropertyNamesWithoutIdCapitalization(shippingMethod) as ShippingMethodDTO);
        }
        this.shippingMethods.next(shippingMethodsFromBack);
      }
    });
    return this.shippingMethodModel.getAll();
  }

  getShippingMethod(id: number): ShippingMethodDTO {
    return this.shippingMethodModel.get(id);
  }

  insertShippingMethod(name: String, cost: Number): boolean{
    try{
      this.shippingMethodModel.insertShippingMethod(name, cost)
      return true;
    } catch(ex){
      return false;
    }
  }

  deleteShippingMethod(id: number): String[] {
    let errors = [];
    let orders = this.ordersModel.getAll() as Array<OrderDTO>;
    for (let order of orders) {
      if (order.ShippingMethod.id == id) {
        errors.push('Referential integrity violation.');
        break;
      }
    }

    if (errors.length == 0) {
      this.shippingMethodModel.deleteItem(id);
    }

    return errors;
  }
}
