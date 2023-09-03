import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { VALIDATORS, capitalizeFirstLetter } from 'common';
import { ErrorModalService } from 'src/app/Services/error-modal.service';
import { LanguagesService } from 'src/app/Services/languages.service';
import { LanguageDTO } from 'src/tsBusinessLayer/dtos/LanguageDTO';

@Component({
  selector: 'app-admin-language-insert',
  templateUrl: './admin-language-insert.component.html',
  styleUrls: ['./admin-language-insert.component.scss']
})
export class AdminLanguageInsertComponent {
  constructor(
    private _modalErrorService: ErrorModalService,
    private _languagesService: LanguagesService,
    private router: Router
  ) {}

  public formSubmitted(e: SubmitEvent) {
    e.preventDefault();
    const data = new FormData(e.target as HTMLFormElement);
    let languageName = data.get('name') as String;

    let errors: Array<String> = [];

    if (
      !VALIDATORS.variableNotUndefined(languageName) ||
      !VALIDATORS.stringNotNull(languageName)
    ) {
      errors.push("Language name can't be empty.");
    }

    if (errors.length > 0) {
      this._modalErrorService.setErrors(errors);
    } else {
      this._languagesService.insertLanguage(
        new LanguageDTO(0, capitalizeFirstLetter(languageName as string))
      );
      this.router.navigateByUrl('/admin/panel/languages');
    }
  }
}
