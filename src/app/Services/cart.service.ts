declare var require: any;

import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { IBookCart } from '../Interfaces/IBookCart';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  private cartDataFromJson = require("src/assets/data/cart.json");
  private cart = new BehaviorSubject<Array<IBookCart>>(this.cartDataFromJson);
  public currentDataCart$ = this.cart.asObservable();
  private notificationMessage = new BehaviorSubject<String>("")
  public currentNotifyMessage$ = this.notificationMessage.asObservable();

  constructor() { }

  public changeCart(newData: IBookCart) {
    let bookCart = this.cart.getValue();
    if(bookCart)
    {
      let objIndex = bookCart.findIndex((obj => obj.id == newData.id));
      if(objIndex != -1)
      {
        bookCart[objIndex].Quantity += 1;
      }
      else {
        bookCart.push(newData);
      }  
    }
    else {
      bookCart = [];
      bookCart.push(newData);
    }
    
    this.cart.next(bookCart);
    this.showPopupBottomRight("You have successfully added a book to your cart.")
  }

  public lowerElementQuantityFromCart(newData: IBookCart){
    let bookCart = this.cart.getValue();
    let objIndex = bookCart.findIndex((obj => obj.id == newData.id));
    if(objIndex != -1)
    {
      if( bookCart[objIndex].Quantity==1){
        this.removeElementCart(newData);
      } else{
        bookCart[objIndex].Quantity = bookCart[objIndex].Quantity-1;
      }
    }

    this.showPopupBottomRight("You have successfully removed a book from your cart.")
    this.cart.next(bookCart);
  }

  public removeElementCart(newData:IBookCart){
    let bookCart = this.cart.getValue();
    let objIndex = bookCart.findIndex((obj => obj.id == newData.id));
    if(objIndex != -1)
    {
      bookCart[objIndex].Quantity = 1;
      bookCart.splice(objIndex,1);
    }

    this.cart.next(bookCart);
  }

  public removeAllElements(){
    for(let book of this.cart.getValue()){
      this.removeElementCart(book);
    }
  }

  public showPopupBottomRight(notificationMessage: String){
    this.notificationMessage.next(notificationMessage);
  }

  public setNotificationMessage(message: string){
    this.notificationMessage.next(message);
  }
}