import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { VALIDATORS, capitalizeFirstLetter } from 'common';
import { ErrorModalService } from 'src/app/Services/error-modal.service';
import { HomeService } from 'src/app/Services/home.service';
import { HomeParagraphDTO } from 'src/tsBusinessLayer/dtos/HomeParagraphDTO';

@Component({
  selector: 'app-admin-home-paragraph-update',
  templateUrl: './admin-home-paragraph-update.component.html',
  styleUrls: ['./admin-home-paragraph-update.component.scss']
})
export class AdminHomeParagraphUpdateComponent {

  public homeParagraphToEdit: HomeParagraphDTO;

  constructor(
    private _homeService: HomeService,
    private _modalErrorService: ErrorModalService,
    private _route: ActivatedRoute,
    private _router: Router
  ) {
    let id = parseInt(this._route.snapshot.paramMap.get('id')!);
    this.homeParagraphToEdit = _homeService.getHomeParagraph(id);
  }

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
      this._homeService.editHomeParagraph(
        new HomeParagraphDTO(this.homeParagraphToEdit.id, capitalizeFirstLetter(paragraphText as string))
      );
      this._router.navigateByUrl('/admin/panel/home_paragraphs');
    }
  }
}
