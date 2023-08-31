import { formatDate } from '@angular/common';
import { Component } from '@angular/core';
import { IAuthorAdmin } from 'src/app/Interfaces/IAuthorAdmin';
import { AuthorsService } from 'src/app/Services/authors.service';
import { ErrorModalService } from 'src/app/Services/error-modal.service';
import { AuthorDTO } from 'src/tsBusinessLayer/dtos/AuthorDTO';

@Component({
  selector: 'app-admin-authors',
  templateUrl: './admin-authors.component.html',
  styleUrls: ['./admin-authors.component.scss'],
})
export class AdminAuthorsComponent {
  private authors: Array<AuthorDTO> = [];
  public jsonObjectArrayToDisplay: Array<IAuthorAdmin> = [];

  constructor(private _errorModalService: ErrorModalService, private _authorsService: AuthorsService) {
    this.convertAuthorsDTOToIAuthorAdmins();
  }
  convertAuthorsDTOToIAuthorAdmins(){
    this.authors = this._authorsService.getAuthors() as Array<AuthorDTO>;

    this.jsonObjectArrayToDisplay = [];
    for (let author of this.authors) {
      this.jsonObjectArrayToDisplay.push({
        id: author.id,
        FirstName: author.FirstName,
        LastName: author.LastName,
        BirthDate: formatDate(author.BirthDate, 'MMM d, y', 'en'),
      } as IAuthorAdmin);
    }
  }
  editItem(item: IAuthorAdmin) {
    console.log(item);
  }

  deleteItem(item: IAuthorAdmin) {
    let errors = this._authorsService.deleteAuthor(item.id);

    if(errors.length>0){
      this._errorModalService.setErrors(errors);
    } else{
      this.convertAuthorsDTOToIAuthorAdmins();
    }
  }
}
