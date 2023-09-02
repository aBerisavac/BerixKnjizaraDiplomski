import { Component, OnInit } from '@angular/core';
import { AuthorsService } from 'src/app/Services/authors.service';
import { HttpClient } from '@angular/common/http';
import { UsersService } from 'src/app/Services/users.service';
import { AuthorDTO } from 'src/tsBusinessLayer/dtos/AuthorDTO';
import { ActivatedRoute, Router } from '@angular/router';
import { VALIDATORS, capitalizeFirstLetter } from 'common';
import { ErrorModalService } from 'src/app/Services/error-modal.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-admin-author-update',
  templateUrl: './admin-author-update.component.html',
  styleUrls: ['./admin-author-update.component.scss'],
  providers: [DatePipe]
})
export class AdminAuthorUpdateComponent{

  public authorToEdit: AuthorDTO;
  public convertedBirthDate: string;
  
  constructor(
    private _authorsService: AuthorsService,
    private _modalErrorService: ErrorModalService,
    private _route: ActivatedRoute,
    private _router: Router,
    private _datePipe: DatePipe,
  ){
    let id=parseInt(this._route.snapshot.paramMap.get('id')!);
    this.authorToEdit = _authorsService.getAuthor(id)
    this.convertedBirthDate = this._datePipe.transform(new Date(Date.parse((this.authorToEdit.BirthDate as any) as string)), 'yyyy-MM-dd')!;
  }

   
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
        if (Number.isNaN(Date.parse(authorBirthDate as string))) {
          errors.push('Birth Date is not of correct format.');
        } 
        else{
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
        this._authorsService.updateAuthor(
          new AuthorDTO(
            this.authorToEdit.id,
            capitalizeFirstLetter(authorFirstName as string),
            capitalizeFirstLetter(authorLastName as string),
            new Date(Date.parse(authorBirthDate as string)))
        )
        this._router.navigateByUrl('/admin/panel/authors');
    }
  }
}
