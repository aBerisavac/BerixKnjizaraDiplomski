import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/Services/cart.service';
import { IBookCart } from 'src/app/Interfaces/IBookCart';
import { IAddOrder } from 'src/tsBusinessLayer/interfaces/IAddOrder';
import { OrderModel } from 'src/tsBusinessLayer/Models/OrderModel';
import { ShippingMethodDTO } from 'src/tsBusinessLayer/dtos/ShippingMethodDTO';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {
  public showCheckoutFormBool = false;

  public items: Array<IBookCart> =[]
  public totalPrice:number = 0;
  public totalQuantity:number = 0;
  private orderModel = new OrderModel(this._http);

  constructor(private _cartService:CartService, private _http:HttpClient) { }

  ngOnInit() {
    this._cartService.currentDataCart$.subscribe(x=>{
      if(x)
      {
        this.items = x;
        this.totalQuantity = x.reduce((sum, current) => sum + current.Quantity, 0);;
        this.totalPrice = Math.round(x.reduce((sum, current) => sum + (current.Prices[0].price * current.Quantity), 0));
      }
    })
  }

  public successfullCheckout(data: FormData){
    let dataOrder: IAddOrder = {
      "FirstName": data.get("FirstName") as String,
      "LastName": data.get("LastName") as String,
      "Email": data.get("Email") as String,
      "Address": data.get("Address") as String,
      "Password": data.get("Password") as String,
      "items": JSON.parse(data.get("items") as string) as Array<IBookCart>,
      "ShippingMethod": JSON.parse(data.get("ShippingMethod") as string) as ShippingMethodDTO,
    }
    this.orderModel.addOrder(dataOrder);

    this.showCheckoutFormBool = false;
    window.location.href="/successfull_checkout"
  }

  public removeFromCart(book: IBookCart)
  {
    let bookCart: IBookCart = book as IBookCart;
    this._cartService.lowerElementQuantityFromCart(bookCart);
  }

  public addToCart(book: IBookCart)
  {
    let bookCart: IBookCart = book as IBookCart;
    this._cartService.changeCart(bookCart);
  }
  
  public showCheckoutForm(){
    this.showCheckoutFormBool=true;
  }

}