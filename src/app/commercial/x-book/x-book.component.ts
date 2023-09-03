import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { IBookCart } from 'src/app/Interfaces/IBookCart';
import { CartService } from 'src/app/Services/cart.service';
import { BookDTO } from 'src/tsBusinessLayer/dtos/BookDTO';
@Component({
  selector: 'app-x-book',
  templateUrl: './x-book.component.html',
  styleUrls: ['./x-book.component.scss'],
})
export class XBookComponent implements OnInit {
  @Input() book: BookDTO = {} as BookDTO;
  @ViewChild('listHolder') listHolder: any;
  @ViewChild('genresListHolder') genresListHolder: any;
  @ViewChild('languagesListHolder') languagesListHolder: any;
  public items: Array<IBookCart> = [];
  public currentBookExistsInCart = false;
  public imageURL: string = ""
  constructor(
    private _cartService: CartService,
  ) {}

  ngOnInit() {
    this._cartService.currentDataCart$.subscribe((x) => {
      if (x.length > 0) {
        this.items = x;
        if (this.items.filter((x) => x.id == this.book.id).length > 0) {
          this.currentBookExistsInCart = true;
        } else {
          this.currentBookExistsInCart = false;
        }
      }
    });
  }

  ngAfterViewInit() {
    this.setListsItemLogic();
  }

  public setListItemLogic(listHolder: any) {
    let list = listHolder.nativeElement.querySelector(
      '.list'
    ) as HTMLDivElement;
    let infoHolder = listHolder.nativeElement.querySelector(
      '.info-holder'
    ) as HTMLDivElement;
    infoHolder.addEventListener('click', (e) => {
      if (parseInt(list.style.top) < 0) {
        list.style.top = infoHolder.clientHeight + 5 + 'px';
        (listHolder.nativeElement as HTMLDivElement).style.paddingBottom =
          list.clientHeight + 'px';
      } else {
        list.style.top =
          -list.clientHeight - 5 + infoHolder.clientHeight + 'px';
        (listHolder.nativeElement as HTMLDivElement).style.paddingBottom =
          0 + 'px';
      }
    });
    list.style.top = -list.clientHeight - 5 + 'px';
  }

  public setListsItemLogic() {
    this.setListItemLogic(this.listHolder);
    this.setListItemLogic(this.genresListHolder);
    this.setListItemLogic(this.languagesListHolder);
  }

  public removeFromCart(book: BookDTO) {
    let newBookCart: any = book;
    if (this.items.filter((x) => x.id == book.id).length > 0) {
      newBookCart['Quantity'] = this.items.filter(
        (x) => x.id == book.id
      )[0].Quantity;
    } else {
      newBookCart['Quantity'] = 1;
    }
    let bookCart: IBookCart = newBookCart as IBookCart;
    this._cartService.lowerElementQuantityFromCart(bookCart);

    if (this.items.filter((x) => x.id == this.book.id).length == 0) {
      this.currentBookExistsInCart = false;
    }
  }

  public addToCart(book: BookDTO) {
    let newBookCart: any = book;
    if (this.items.filter((x) => x.id == book.id).length > 0) {
      newBookCart['Quantity'] = this.items.filter(
        (x) => x.id == book.id
      )[0].Quantity;
    } else {
      newBookCart['Quantity'] = 1;
    }
    let bookCart: IBookCart = newBookCart as IBookCart;
    this._cartService.changeCart(bookCart);
  }
}
