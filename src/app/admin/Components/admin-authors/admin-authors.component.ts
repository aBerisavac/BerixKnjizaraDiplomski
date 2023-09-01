import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { IAuthorAdmin } from 'src/app/Interfaces/IAuthorAdmin';
import { AuthorsService } from 'src/app/Services/authors.service';
import { ErrorModalService } from 'src/app/Services/error-modal.service';
import { AuthorDTO } from 'src/tsBusinessLayer/dtos/AuthorDTO';

@Component({
  selector: 'app-admin-authors',
  templateUrl: './admin-authors.component.html',
  styleUrls: ['./admin-authors.component.scss'],
})
export class AdminAuthorsComponent implements OnInit {
  private authors: Array<AuthorDTO> = [];
  public jsonObjectArrayToDisplay: Array<IAuthorAdmin> = [];

  constructor(private _errorModalService: ErrorModalService, private _authorsService: AuthorsService) { }
  ngOnInit(): void {
    this._authorsService.authors$.subscribe(x=>{
      this.authors=x;
      this.convertAuthorsDTOToIAuthorAdmins();
    })
  }

  convertAuthorsDTOToIAuthorAdmins(){
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
    this._authorsService.deleteAuthor(item.id);
  }
}
