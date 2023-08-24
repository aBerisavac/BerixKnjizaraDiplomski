import { Injectable } from '@angular/core';
import { OrderModel } from 'src/tsBusinessLayer/Models/OrderModel';
import { ShippingMethodModel } from 'src/tsBusinessLayer/Models/ShippingMethodModel';
import { OrderDTO } from 'src/tsBusinessLayer/dtos/OrderDTO';
import { ShippingMethodDTO } from 'src/tsBusinessLayer/dtos/ShippingMethodDTO';

@Injectable({
  providedIn: 'root',
})
export class ShippingMethodsService {
  constructor() {}

  private ordersModel: OrderModel = new OrderModel();
  private shippingMethodModel = new ShippingMethodModel();

  getShippingMethods(): ShippingMethodDTO[] {
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
