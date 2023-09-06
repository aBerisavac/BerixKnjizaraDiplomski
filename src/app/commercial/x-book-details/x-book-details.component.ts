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
  styleUrls: ['./x-book-details.component.scss'],
})
export class XBookDetailsComponent implements OnInit {
  id: string = '';
  book: BookDTO | null = null;
  formattedDate: String = '';
  public items: Array<IBookCart> = [];
  public currentBookExistsInCart = false;

  constructor(
    private booksService: BooksService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.booksService.books$.subscribe((x) => {
      if (x.length>0) {
        this.id = this.route.snapshot.paramMap.get('id')!;
        this.book = this.booksService.getBook(parseInt(this.id));
        this.formattedDate = formatDate(
          this.book.ReleaseDate,
          'MMM d, y',
          'en'
        );
      }
    });
  }
}
