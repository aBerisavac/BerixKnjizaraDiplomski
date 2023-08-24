declare var require: any;

import { GenreDTO } from '../dtos/GenreDTO';
import { IEntityGet } from '../interfaces/common/IEntityGet';
import { IEntityGetAll } from '../interfaces/common/IEntityGetAll';
import { TBookJSON } from '../types/JSON/TBookJson';
import { TGenreJson } from '../types/JSON/TGenreJson';

export class GenreModel implements IEntityGetAll, IEntityGet {
  private genres: Array<GenreDTO> = [];

  constructor() {
    if (localStorage.getItem('Genres') == undefined) {
      let genres: Array<TGenreJson> = require('src/assets/data/genre.json');
      this.genres = this.convertGenreFromJsonToDTO(genres);
      localStorage.setItem('Genres', JSON.stringify(this.genres));
    } else {
      this.genres = JSON.parse(localStorage.getItem('Genres')!);
    }
  }

  public getAll<GenreDTO>(): Array<GenreDTO> {
    return this.genres as Array<GenreDTO>;
  }

  private getMaxId(){
    let maxId = this.genres.sort((x,y)=>y.id-x.id)[0].id;
    this.genres.sort((x,y)=>x.id-y.id)[0].id
    return maxId;
  }

  public get<GenreDTO>(id: number): /*  */ GenreDTO {
    return this.genres.filter((x) => x.id == id)[0] as GenreDTO;
  }

  public insertGenre(name: String){
    this.genres.push({
      "id": this.getMaxId()+1,
      "Name": name,
    } as GenreDTO)

    localStorage.setItem(
      'Genres',
      JSON.stringify(this.genres)
    );
  }

  public deleteItem(id: number){
      let helpingArray: Array<GenreDTO> = [];
      for (let genre of this.genres) {
        if (genre.id != id) {
          helpingArray.push(genre);
        }
      }

      this.genres = helpingArray;

      localStorage.setItem(
        'Genres',
        JSON.stringify(this.genres)
      );
  }

  public getGenresByBook(book: TBookJSON): Array<GenreDTO> {
    let genreIdsArray = book.Genres;

    let genres: Array<GenreDTO> = [];
    for (let genreId of genreIdsArray) {
      genres.push(this.get(genreId));
    }

    return genres;
  }

  

  private convertGenreFromJsonToDTO(
    genres: Array<TGenreJson>
  ): Array<GenreDTO> {
    let genresDTO: Array<GenreDTO> = [];
    for (let genre of genres) {
      genresDTO.push({
        id: genre.id,
        Name: genre.Name,
      });
    }

    return genresDTO;
  }
}
