import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { VALIDATORS, capitalizeFirstLetter } from 'common';
import { ErrorModalService } from 'src/app/Services/error-modal.service';
import { HomeService } from 'src/app/Services/home.service';
import { HomeParagraphDTO } from 'src/tsBusinessLayer/dtos/HomeParagraphDTO';

@Component({
  selector: 'app-admin-home-paragraph-insert',
  templateUrl: './admin-home-paragraph-insert.component.html',
  styleUrls: ['./admin-home-paragraph-insert.component.scss']
})
export class AdminHomeParagraphInsertComponent {
  constructor(
    private _modalErrorService: ErrorModalService,
    private _homeService: HomeService,
    private router: Router
  ) {}

  public formSubmitted(e: SubmitEvent) {
    e.preventDefault();
    const data = new FormData(e.target as HTMLFormElement);
    let paragraphText = data.get('name') as String;

    let errors: Array<String> = [];

    if (
      !VALIDATORS.variableNotUndefined(paragraphText) ||
      !VALIDATORS.stringNotNull(paragraphText)
    ) {
      errors.push("Paragraph can't be empty.");
    }

    if (errors.length > 0) {
      this._modalErrorService.setErrors(errors);
    } else {
      this._homeService.insertHomeParagraph(
        new HomeParagraphDTO(0, capitalizeFirstLetter(paragraphText as string))
      );
      this.router.navigateByUrl('/admin/panel/home_paragraphs');
    }
  }
}
