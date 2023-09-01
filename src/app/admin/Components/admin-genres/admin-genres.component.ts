import { Component, OnInit } from '@angular/core';
import { GenresService } from 'src/app/Services/genres.service';
import { GenreDTO } from 'src/tsBusinessLayer/dtos/GenreDTO';

@Component({
  selector: 'app-admin-genres',
  templateUrl: './admin-genres.component.html',
  styleUrls: ['./admin-genres.component.scss']
})
export class AdminGenresComponent implements OnInit{
  public jsonObjectArrayToDisplay: Array<GenreDTO> = [];

  constructor(
    private _genreService: GenresService, 
    ){
  }
  ngOnInit(): void {
    this._genreService.genres$.subscribe(x=>this.jsonObjectArrayToDisplay = x);
  }

  editItem(item: GenreDTO){
    console.log(item)
  }

  deleteItem(item: GenreDTO){
    this._genreService.deleteGenre(item.id)

  }
}
