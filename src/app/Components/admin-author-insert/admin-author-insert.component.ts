import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { VALIDATORS, capitalizeFirstLetter } from 'common';
import { AuthorsService } from 'src/app/Services/authors.service';
import { ErrorModalService } from 'src/app/Services/error-modal.service';

@Component({
  selector: 'app-admin-author-insert',
  templateUrl: './admin-author-insert.component.html',
  styleUrls: ['./admin-author-insert.component.scss'],
})
export class AdminAuthorInsertComponent {
  constructor(
    private _modalErrorService: ErrorModalService,
    private _authorService: AuthorsService,
    private router: Router
  ) {}

  public formSubmitted(e: SubmitEvent) {
    e.preventDefault();
    const data = new FormData(e.target as HTMLFormElement);
    let authorFirstName = data.get('first-name') as String;
    let authorLastName = data.get('last-name') as String;
    let authorBirthDate = data.get('birth-date') as String;

    let errors: Array<String> = [];

    if (
      !VALIDATORS.variableNotUndefined(authorFirstName) ||
      !VALIDATORS.stringNotNull(authorFirstName)
    ) {
      errors.push("First Name can't be empty.");
    }

    if (
      !VALIDATORS.variableNotUndefined(authorLastName) ||
      !VALIDATORS.stringNotNull(authorLastName)
    ) {
      errors.push("Last Name can't be empty.");
    }

    if (
      !VALIDATORS.variableNotUndefined(authorBirthDate) ||
      !VALIDATORS.stringNotNull(authorBirthDate)
    ) {
      errors.push("Birth Date can't be empty.");
    } else {
      try {
        console.log(Date.parse(authorBirthDate as string));

        if (Number.isNaN(Date.parse(authorBirthDate as string))) {
          errors.push('Birth Date is not of correct format.');
        } else{
          if(new Date(Date.parse(authorBirthDate as string))>new Date()){
            errors.push("Birth Date can't be in the future");
          }
        }
      } catch (ex) {
        errors.push('Birth Date is not of correct format.');
      }
    }

    if (errors.length > 0) {
      this._modalErrorService.setErrors(errors);
    } else {
      if (
        this._authorService.insertAuthor(
          capitalizeFirstLetter(authorFirstName as string),
          capitalizeFirstLetter(authorLastName as string),
          new Date(Date.parse(authorBirthDate as string))
        )
      ) {
        this.router.navigateByUrl('/admin/authors');
      } else {
        this._modalErrorService.setErrors([
          'There was an error storing data. Try again later.',
        ]);
      }
    }
  }
}
