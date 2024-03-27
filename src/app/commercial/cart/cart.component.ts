import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/Services/cart.service';
import { IBookCart } from 'src/app/Interfaces/IBookCart';
import { ShippingMethodDTO } from 'src/tsBusinessLayer/dtos/ShippingMethodDTO';
import { HttpClient } from '@angular/common/http';
import { OrdersService } from 'src/app/Services/orders.service';
import { OrderDTO } from 'src/tsBusinessLayer/dtos/OrderDTO';
import { UsersService } from 'src/app/Services/users.service';
import { OrderInvoiceDTO } from 'src/tsBusinessLayer/dtos/OrderInvoiceDTO';
import { BookDTO } from 'src/tsBusinessLayer/dtos/BookDTO';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss'],
})
export class CartComponent implements OnInit {
  public showCheckoutFormBool = false;

  public items: Array<IBookCart> = [];
  public totalPrice: number = 0;
  public totalQuantity: number = 0;

  constructor(
    private _cartService: CartService,
    private _ordersService: OrdersService,
    private _userService: UsersService,
    private _http: HttpClient,
  ) {}

  ngOnInit() {
    this._cartService.currentDataCart$.subscribe((x) => {
      if (x) {
        this.items = x;
        this.totalQuantity = x.reduce(
          (sum, current) => sum + current.Quantity,
          0
        );
        this.totalPrice = Math.round(
          x.reduce(
            (sum, current) => sum + current.Prices[0].price * current.Quantity,
            0
          )
        );
      }
    });
  }

  public successfullCheckout(data: FormData) {
    let orderInvoices: OrderInvoiceDTO[] = [];
    let items = JSON.parse(data.get("items") as string) as Array<IBookCart>;
    for (let item of items){
      orderInvoices.push({
        "Book": new BookDTO(item.id, item.Title, item.Description, item.ImageSrc, item.ReleaseDate, item.Authors, item.Genres, item.Languages, item.Prices),
        "id": 0,
        "NumberOfItems": item.Quantity
      })
    }

    let dataOrder: OrderDTO = {
      id: 0,
      ShippingMethod: JSON.parse(
        data.get('ShippingMethod') as string
      ) as ShippingMethodDTO,
      Customer: this._userService.getUserData()!,
      OrderInvoices: orderInvoices,
      ShippingAddress: data.get("ShippingAddress") as string
    };

    console.log(dataOrder)
    this._ordersService.insertOrder(dataOrder)

    this.showCheckoutFormBool = false;
    // window.location.href = '/successfull_checkout';
  }

  public removeFromCart(book: IBookCart) {
    let bookCart: IBookCart = book as IBookCart;
    this._cartService.lowerElementQuantityFromCart(bookCart);
  }

  public addToCart(book: IBookCart) {
    let bookCart: IBookCart = book as IBookCart;
    this._cartService.changeCart(bookCart);
  }

  public showCheckoutForm() {
    if(this._userService.getUserData()==undefined){
      this._cartService.setNotificationMessage("You need to login before you are able to buy.");
    } else{
      this.showCheckoutFormBool = true;
    }
  }
}
