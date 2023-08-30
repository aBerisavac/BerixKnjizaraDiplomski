import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/Services/cart.service';
import { IBookCart } from 'src/app/Interfaces/IBookCart';

@Component({
  selector: 'app-cart-popup',
  templateUrl: './cart-popup.component.html',
  styleUrls: ['./cart-popup.component.scss']
})
export class CartPopupComponent implements OnInit {

  public items: Array<IBookCart> =[]
  public totalPrice:number = 0;
  public totalQuantity:number = 0;
  constructor(private _cartService:CartService) { }

  ngOnInit() {
    this._cartService.currentDataCart$.subscribe(x=>{
      if(x)
      {
        this.items = x;
        this.totalQuantity = x.length;
        this.totalPrice = x.reduce((sum, current) => sum + (current.Prices[0].price * current.Quantity), 0);
      }
    })
  }

  public remove(producto:IBookCart)
  {
    this._cartService.removeElementCart(producto);
  }
  

}