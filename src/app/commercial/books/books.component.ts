import { Component, OnInit } from '@angular/core';
import { BooksService } from 'src/app/Services/books.service';
import { BookDTO } from 'src/tsBusinessLayer/dtos/BookDTO';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.scss']
})
export class BooksComponent implements OnInit{
  public books: Array<BookDTO> = []
  private booksService: BooksService;

  constructor(booksService: BooksService ){
    this.booksService=booksService;
  }
  ngOnInit(): void {
    this.booksService.books$.subscribe(x=>{
      this.books = x;
    })
  }

}
