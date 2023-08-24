declare var require: any;

import { LanguageDTO } from '../dtos/LanguageDTO';
import { IEntityGet } from '../interfaces/common/IEntityGet';
import { IEntityGetAll } from '../interfaces/common/IEntityGetAll';
import { TBookJSON } from '../types/JSON/TBookJson';
import { TLanguageJson } from '../types/JSON/TLanguageJson';

export class LanguageModel implements IEntityGetAll, IEntityGet {
  private languages: Array<LanguageDTO> = [];

  constructor() {
    if (localStorage.getItem('Languages') == undefined) {
      let languages: Array<TLanguageJson> = require('src/assets/data/language.json');
      this.languages = this.convertLanguageFromJsonToDTO(languages);
      localStorage.setItem('Languages', JSON.stringify(this.languages));
    } else {
      this.languages = JSON.parse(localStorage.getItem('Languages')!);
    }
  }

  public getAll<LanguageDTO>(): Array<LanguageDTO> {
    return this.languages as Array<LanguageDTO>;
  }

  public get<LanguageDTO>(id: number): LanguageDTO {
    return this.languages.filter((x) => x.id == id)[0] as LanguageDTO;
  }

  public getLanguagesByBook(book: TBookJSON): Array<LanguageDTO> {
    let languageIdsArray = book.Languages;

    let languages: Array<LanguageDTO> = [];
    for (let languageId of languageIdsArray) {
      languages.push(this.get(languageId));
    }

    return languages;
  }

  private convertLanguageFromJsonToDTO(
    languages: Array<TLanguageJson>
  ): Array<LanguageDTO> {
    let languagesDTO: Array<LanguageDTO> = [];
    for (let language of languages) {
      languagesDTO.push({
        id: language.id,
        Name: language.Language,
      });
    }

    return languagesDTO;
  }
}
