import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { VALIDATORS, capitalizeFirstLetter } from 'common';
import { AuthorsService } from 'src/app/Services/authors.service';
import { BooksService } from 'src/app/Services/books.service';
import { ErrorModalService } from 'src/app/Services/error-modal.service';
import { GenresService } from 'src/app/Services/genres.service';
import { LanguagesService } from 'src/app/Services/languages.service';
import { AuthorDTO } from 'src/tsBusinessLayer/dtos/AuthorDTO';
import { GenreDTO } from 'src/tsBusinessLayer/dtos/GenreDTO';
import { LanguageDTO } from 'src/tsBusinessLayer/dtos/LanguageDTO';

@Component({
  selector: 'app-admin-book-insert',
  templateUrl: './admin-book-insert.component.html',
  styleUrls: ['./admin-book-insert.component.scss']
})
export class AdminBookInsertComponent implements OnInit {
  public authors: AuthorDTO[] = [];
  public genres: GenreDTO[] = [];
  public languages: LanguageDTO[] = [];

  constructor(
    private _modalErrorService: ErrorModalService,
    private _bookService: BooksService,
    private _authorService: AuthorsService,
    private _genreService: GenresService,
    private _languageService: LanguagesService,
    private router: Router
  ) {
  }
  ngOnInit(): void {
    this._authorService.authors$.subscribe(x=>this.authors=x);
    this._genreService.genres$.subscribe(x=>this.genres=x);
    this._languageService.languages$.subscribe(x=>this.languages=x);
  }

  public formSubmitted(e: SubmitEvent) {
    e.preventDefault();
    const data = new FormData(e.target as HTMLFormElement);
    let bookTitle = data.get('title') as String;
    let bookDescription = data.get('description') as String;
    let bookPrice = data.get('price') as String;
    let bookImageSrc = data.get('image-src') as String;
    let bookReleaseDate = data.get('release-date') as String;
    let bookAuthors = data.getAll('authors');
    let bookGenres = data.getAll('genres');
    let bookLanguages = data.getAll('languages');

    let errors: Array<String> = [];

    if(bookAuthors.length==0){
      errors.push("Some author must be selected");
    }

    if(bookGenres.length==0){
      errors.push("Some genre must be selected");
    }

    if(bookLanguages.length==0){
      errors.push("Some language must be selected");
    }

    if (
      !VALIDATORS.variableNotUndefined(bookTitle) ||
      !VALIDATORS.stringNotNull(bookTitle)
    ) {
      errors.push("Title can't be empty.");
    }

    if (
      !VALIDATORS.variableNotUndefined(bookImageSrc) ||
      !VALIDATORS.stringNotNull(bookImageSrc)
    ) {
      errors.push("Image src can't be empty.");
    }

    if (
      !VALIDATORS.variableNotUndefined(bookDescription) ||
      !VALIDATORS.stringNotNull(bookDescription)
    ) {
      errors.push("Description can't be empty.");
    }

    if (
      !VALIDATORS.variableNotUndefined(bookReleaseDate) ||
      !VALIDATORS.stringNotNull(bookReleaseDate)
    ) {
      errors.push("Release date can't be empty.");
    } else {
      try {

        if (Number.isNaN(Date.parse(bookReleaseDate as string))) {
          errors.push('Release date is not of correct format.');
        } else{
          if(new Date(Date.parse(bookReleaseDate as string))>new Date()){
            errors.push("Release date can't be in the future");
          }
        }
      } catch (ex) {
        errors.push('Release date is not of correct format.');
      }
    }

    if (
      !VALIDATORS.variableNotUndefined(bookPrice) ||
      !VALIDATORS.stringNotNull(bookPrice)
    ) {
      errors.push("Book price can't be empty.");
    } else {
      if (!VALIDATORS.isNumber(bookPrice as string)) {
        errors.push(
          "Book price can't be converted to number. Make sure you are using '.' for decimals."
        );
      } else {
        if (!VALIDATORS.min(bookPrice as string, 0)) {
          errors.push('Book price must be a positive number.');
        }
      }
    }

    if (errors.length > 0) {
      this._modalErrorService.setErrors(errors);
    } else {
        this._bookService.insertBook(
          capitalizeFirstLetter(bookTitle as string),
          bookDescription,
          bookImageSrc, 
          new Date(Date.parse(bookReleaseDate as string)),
          bookAuthors as string[],
          bookGenres as string[],
          bookLanguages as string[],
          parseFloat(bookPrice as string)
        )
        this.router.navigateByUrl('/admin/panel/books');
    }
  }
}
