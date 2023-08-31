import { formatDate } from '@angular/common';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthorsService } from 'src/app/Services/authors.service';
import { BooksService } from 'src/app/Services/books.service';
import { AuthorDTO } from 'src/tsBusinessLayer/dtos/AuthorDTO';
import { BookDTO } from 'src/tsBusinessLayer/dtos/BookDTO';

@Component({
  selector: 'app-x-author-details',
  templateUrl: './x-author-details.component.html',
  styleUrls: ['./x-author-details.component.scss']
})
export class XAuthorDetailsComponent {
  public id: string;
  public author: AuthorDTO;
  public formattedDate: string;
  public booksByAuthor: Array<BookDTO>;

  constructor(private authorsService: AuthorsService, private route: ActivatedRoute, private booksService: BooksService){
    this.id = this.route.snapshot.paramMap.get('id')!;
    this.author=this.authorsService.getAuthor(parseInt(this.id));
    this.formattedDate = formatDate(this.author.BirthDate, "MMM d, y", "en")
    this.booksByAuthor = this.booksService.getBooksWrittenByAuthor(this.author.id)
  }
}
