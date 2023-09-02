import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
    private _router: Router, 
    ){
  }
  ngOnInit(): void {
    this._genreService.genres$.subscribe(x=>this.jsonObjectArrayToDisplay = x);
  }

  editItem(item: GenreDTO){
    this._router.navigateByUrl(`${this._router.url}/edit/${item.id}`)
  }

  deleteItem(item: GenreDTO){
    this._genreService.deleteGenre(item.id)

  }
}
