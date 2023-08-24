import { Component } from '@angular/core';
import { ErrorModalService } from 'src/app/Services/error-modal.service';
import { GenresService } from 'src/app/Services/genres.service';
import { GenreDTO } from 'src/tsBusinessLayer/dtos/GenreDTO';

@Component({
  selector: 'app-admin-genres',
  templateUrl: './admin-genres.component.html',
  styleUrls: ['./admin-genres.component.scss']
})
export class AdminGenresComponent{
  public jsonObjectArrayToDisplay: Array<GenreDTO> = [];

  constructor(private _errorModalService: ErrorModalService, private _genreService: GenresService){
    this.jsonObjectArrayToDisplay = this._genreService.getGenres() as Array<GenreDTO>;
  }

  editItem(item: GenreDTO){
    console.log(item)
  }

  deleteItem(item: GenreDTO){
    let errors = this._genreService.deleteGenre(item.id);

    if(errors.length>0){
      this._errorModalService.setErrors(errors);
    } else{
      this.jsonObjectArrayToDisplay = this._genreService.getGenres() as Array<GenreDTO>;
    }
  }
}
