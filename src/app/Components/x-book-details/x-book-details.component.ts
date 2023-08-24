import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IBookCart } from 'src/app/Interfaces/IBookCart';
import { BooksService } from 'src/app/Services/books.service';
import { CartService } from 'src/app/Services/cart.service';
import { BookDTO } from 'src/tsBusinessLayer/dtos/BookDTO';

@Component({
  selector: 'app-x-book-details',
  templateUrl: './x-book-details.component.html',
  styleUrls: ['./x-book-details.component.scss']
})
export class XBookDetailsComponent implements OnInit {
  id: string;
  book: BookDTO;
  formattedDate: String = "";
  public items: Array<IBookCart> =[];
  public currentBookExistsInCart = false;

  constructor(private booksService: BooksService, private route: ActivatedRoute, private _cartService: CartService) {
    this.id = this.route.snapshot.paramMap.get('id')!;
    this.book=this.booksService.getBook(parseInt(this.id));
    this.formattedDate = formatDate(this.book.ReleaseDate, "MMM d, y", "en")
  }

  ngOnInit() {
    this._cartService.currentDataCart$.subscribe(x=>{
      if(x.length>0)
      {
        this.items = x;
        if(this.items.filter(x=>x.id==this.book.id).length>0){
          this.currentBookExistsInCart = true;
        } else{
          this.currentBookExistsInCart = false;
        }
      }
    })
  }

  public removeFromCart(book: BookDTO)
  {
    let newBookCart: any = book;
    if(this.items.filter(x=>x.id==book.id).length>0){
      newBookCart["Quantity"]=this.items.filter(x=>x.id==book.id)[0].Quantity
    } else{
      newBookCart["Quantity"]=1;
    }
    let bookCart: IBookCart = newBookCart as IBookCart;
    this._cartService.lowerElementQuantityFromCart(bookCart);

    if(this.items.filter(x=>x.id==this.book.id).length==0){
      this.currentBookExistsInCart = false;
    }
  }

  public addToCart(book: BookDTO)
  {
    let newBookCart: any = book;
    if(this.items.filter(x=>x.id==book.id).length>0){
      newBookCart["Quantity"]=this.items.filter(x=>x.id==book.id)[0].Quantity
    } else{
      newBookCart["Quantity"]=1;
    }
    let bookCart: IBookCart = newBookCart as IBookCart;
    this._cartService.changeCart(bookCart);
  }
}
