declare var require: any;

import { AuthorDTO } from '../dtos/AuthorDTO';
import { IEntityGet } from '../interfaces/common/IEntityGet';
import { IEntityGetAll } from '../interfaces/common/IEntityGetAll';
import { TAuthorJson } from '../types/JSON/TAuthorJson';
import { TBookJSON } from '../types/JSON/TBookJson';

export class AuthorModel implements IEntityGetAll, IEntityGet {
  private authors: Array<AuthorDTO> = [];

  constructor() {
    if (localStorage.getItem('Authors') == undefined) {
      let authors: Array<TAuthorJson> = require('src/assets/data/author.json');
      this.authors = this.convertAuthorFromJsonToDTO(authors);
      localStorage.setItem('Authors', JSON.stringify(this.authors));
    } else {
      this.authors = JSON.parse(localStorage.getItem('Authors')!);
    }
  }

  public getAll<AuthorDTO>(): Array<AuthorDTO> {
    return this.authors as Array<AuthorDTO>;
  }

  private getMaxId(){
    let maxId = this.authors.sort((x,y)=>y.id-x.id)[0].id;
    this.authors.sort((x,y)=>x.id-y.id)[0].id
    return maxId;
  }

  public get<AuthorDTO>(id: number): AuthorDTO {
    return this.authors.filter((x) => x.id == id)[0] as AuthorDTO;
  }

  public insertAuthor(firstName: String, lastName: String, birthDate: Date){
    this.authors.push({
      "id": this.getMaxId()+1,
      "FirstName": firstName,
      "LastName": lastName,
      "BirthDate": birthDate
    } as AuthorDTO)

    localStorage.setItem(
      'Authors',
      JSON.stringify(this.authors)
    );
  }

  public getAuthorsByBook(book: TBookJSON): Array<AuthorDTO> {
    let authorIdsArray = book.Authors;

    let authors: Array<AuthorDTO> = [];
    for (let authorId of authorIdsArray) {
      authors.push(this.get(authorId));
    }

    return authors;
  }

  public deleteItem(id: number) {

      let helpingArray: Array<AuthorDTO> = [];
      for (let author of this.authors) {
        if (author.id != id) {
          helpingArray.push(author);
        }
      }

      this.authors = helpingArray;

      localStorage.setItem(
        'Authors',
        JSON.stringify(this.authors)
      );
  }

  private convertAuthorFromJsonToDTO(
    authors: Array<TAuthorJson>
  ): Array<AuthorDTO> {
    let authorsDTO: Array<AuthorDTO> = [];
    for (let author of authors) {
      authorsDTO.push({
        id: author.id,
        FirstName: author.FirstName,
        LastName: author.LastName,
        BirthDate: new Date(`${author.BirthDate}`),
      });
    }

    return authorsDTO;
  }
}
