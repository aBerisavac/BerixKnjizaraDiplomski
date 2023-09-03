import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { VALIDATORS, capitalizeFirstLetter } from 'common';
import { ErrorModalService } from 'src/app/Services/error-modal.service';
import { LanguagesService } from 'src/app/Services/languages.service';
import { LanguageDTO } from 'src/tsBusinessLayer/dtos/LanguageDTO';

@Component({
  selector: 'app-admin-language-update',
  templateUrl: './admin-language-update.component.html',
  styleUrls: ['./admin-language-update.component.scss']
})
export class AdminLanguageUpdateComponent {
  public languageToEdit: LanguageDTO;

  constructor(
    private _languagesService: LanguagesService,
    private _modalErrorService: ErrorModalService,
    private _route: ActivatedRoute,
    private _router: Router
  ) {
    let id = parseInt(this._route.snapshot.paramMap.get('id')!);
    this.languageToEdit = _languagesService.getLanguage(id);
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
      errors.push("Language name can't be empty.");
    }

    if (errors.length > 0) {
      this._modalErrorService.setErrors(errors);
    } else {
      this._languagesService.editLanguage(
        new LanguageDTO(this.languageToEdit.id, capitalizeFirstLetter(genreName as string))
      );
      this._router.navigateByUrl('/admin/panel/languages');
    }
  }
}
