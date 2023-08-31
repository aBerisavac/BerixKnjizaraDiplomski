import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { VALIDATORS, capitalizeFirstLetter } from 'common';
import { ErrorModalService } from 'src/app/Services/error-modal.service';
import { GenresService } from 'src/app/Services/genres.service';

@Component({
  selector: 'app-admin-genre-insert',
  templateUrl: './admin-genre-insert.component.html',
  styleUrls: ['./admin-genre-insert.component.scss'],
})
export class AdminGenreInsertComponent {
  constructor(
    private _modalErrorService: ErrorModalService,
    private _genreService: GenresService,
    private router: Router
  ) {}

  public formSubmitted(e: SubmitEvent) {
    e.preventDefault();
    const data = new FormData(e.target as HTMLFormElement);
    let genreName = data.get('name') as String;

    let errors: Array<String> = [];

    if (
      !VALIDATORS.variableNotUndefined(genreName) ||
      !VALIDATORS.stringNotNull(genreName)
    ) {
      errors.push("Genre name can't be empty.");
    }

    if (errors.length > 0) {
      this._modalErrorService.setErrors(errors);
    } else {
      if (this._genreService.insertGenre(capitalizeFirstLetter(genreName as string))) {
        this.router.navigateByUrl('/admin/genres');
      } else {
        this._modalErrorService.setErrors([
          'There was an error storing data. Try again later.',
        ]);
      }
    }
  }
}
