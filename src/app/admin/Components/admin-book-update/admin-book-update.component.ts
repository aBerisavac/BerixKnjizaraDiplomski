import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { VALIDATORS, capitalizeFirstLetter } from 'common';
import { AuthorsService } from 'src/app/Services/authors.service';
import { BooksService } from 'src/app/Services/books.service';
import { ErrorModalService } from 'src/app/Services/error-modal.service';
import { GenresService } from 'src/app/Services/genres.service';
import { LanguagesService } from 'src/app/Services/languages.service';
import { AuthorDTO } from 'src/tsBusinessLayer/dtos/AuthorDTO';
import { BookDTO } from 'src/tsBusinessLayer/dtos/BookDTO';
import { GenreDTO } from 'src/tsBusinessLayer/dtos/GenreDTO';
import { LanguageDTO } from 'src/tsBusinessLayer/dtos/LanguageDTO';
import { FormsModule } from '@angular/forms';
import { BookPriceDTO } from 'src/tsBusinessLayer/dtos/BookPriceDTO';

@Component({
  selector: 'app-admin-book-update',
  templateUrl: './admin-book-update.component.html',
  styleUrls: ['./admin-book-update.component.scss'],
  providers: [DatePipe],
})
export class AdminBookUpdateComponent {
  public bookToEdit: BookDTO;
  public convertedReleaseDate: string;

  public authors: AuthorDTO[] = [];
  public genres: GenreDTO[] = [];
  public languages: LanguageDTO[] = [];

  public selectedAuthors: number[] = [];
  public selectedGenres: number[] = [];
  public selectedLanguages: number[] = [];

  constructor(
    private _booksService: BooksService,
    private _modalErrorService: ErrorModalService,
    private _genresService: GenresService,
    private _languagesService: LanguagesService,
    private _authorsService: AuthorsService,
    private _route: ActivatedRoute,
    private _router: Router,
    private _datePipe: DatePipe
  ) {
    let id = parseInt(this._route.snapshot.paramMap.get('id')!);
    this.bookToEdit = _booksService.getBook(id);
    this.convertedReleaseDate = this._datePipe.transform(
      new Date(Date.parse(this.bookToEdit.ReleaseDate as any as string)),
      'yyyy-MM-dd'
    )!;

    this._authorsService.authors$.subscribe((x) => (this.authors = x));
    this._genresService.genres$.subscribe((x) => (this.genres = x));
    this._languagesService.languages$.subscribe((x) => (this.languages = x));

    this.selectedAuthors = this.bookToEdit.Authors.map((author) => author.id);
    this.selectedGenres = this.bookToEdit.Genres.map((genre) => genre.id);
    this.selectedLanguages = this.bookToEdit.Languages.map(
      (language) => language.id
    );
  }

  public formSubmitted(e: SubmitEvent) {
    e.preventDefault();
    const data = new FormData(e.target as HTMLFormElement);
    let bookTitle = data.get('title') as String;
    let bookDescription = data.get('description') as String;
    let bookPrice = (data.get('price') as String);
    let bookImageSrc = data.get('image-src') as String;
    let bookReleaseDate = data.get('release-date') as String;
    let bookAuthors = data.getAll('authors');
    let bookGenres = data.getAll('genres');
    let bookLanguages = data.getAll('languages');

    let errors: Array<String> = [];

    if (bookAuthors.length == 0) {
      errors.push('Some author must be selected');
    }

    if (bookGenres.length == 0) {
      errors.push('Some genre must be selected');
    }

    if (bookLanguages.length == 0) {
      errors.push('Some language must be selected');
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
        } else {
          if (new Date(Date.parse(bookReleaseDate as string)) > new Date()) {
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
      let languages = this.languages.filter(x=>(bookLanguages as string[]).includes(`${x.id}`));
      let genres = this.genres.filter(x=>(bookGenres as string[]).includes(`${x.id}`));
      let authors = this.authors.filter(x=>(bookAuthors as string[]).includes(`${x.id}`));

      this._booksService.editBook(
        new BookDTO(
          this.bookToEdit.id,
          capitalizeFirstLetter(bookTitle as string),
          bookDescription,
          bookImageSrc,
          new Date(Date.parse(bookReleaseDate as any as string)),
          authors,
          genres,
          languages,
          [new BookPriceDTO(0, parseInt(bookPrice as string))]
        )
      );
      this._router.navigateByUrl('/admin/panel/books');
    }
  }
}
