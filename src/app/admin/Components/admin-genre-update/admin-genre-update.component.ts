import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { VALIDATORS, capitalizeFirstLetter } from 'common';
import { ErrorModalService } from 'src/app/Services/error-modal.service';
import { GenresService } from 'src/app/Services/genres.service';
import { GenreDTO } from 'src/tsBusinessLayer/dtos/GenreDTO';

@Component({
  selector: 'app-admin-genre-update',
  templateUrl: './admin-genre-update.component.html',
  styleUrls: ['./admin-genre-update.component.scss'],
})
export class AdminGenreUpdateComponent {
  public genreToEdit: GenreDTO;

  constructor(
    private _genresService: GenresService,
    private _modalErrorService: ErrorModalService,
    private _route: ActivatedRoute,
    private _router: Router
  ) {
    let id = parseInt(this._route.snapshot.paramMap.get('id')!);
    this.genreToEdit = _genresService.getGenre(id);
  }

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
      this._genresService.editGenre(
        new GenreDTO(this.genreToEdit.id, capitalizeFirstLetter(genreName as string))
      );
      this._router.navigateByUrl('/admin/panel/genres');
    }
  }
}
