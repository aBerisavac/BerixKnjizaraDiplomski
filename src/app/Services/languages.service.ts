import { Injectable } from '@angular/core';
import { LanguageModel } from 'src/tsBusinessLayer/Models/LanguageModel';
import { LanguageDTO } from 'src/tsBusinessLayer/dtos/LanguageDTO';

@Injectable({
  providedIn: 'root'
})
export class LanguagesService {

  constructor() { }

  private languageModel = new LanguageModel();

  getLanguages(): LanguageDTO[] {
    return this.languageModel.getAll();
  }

  getLlanguage(id: number): LanguageDTO {
    return this.languageModel.get(id);
  }

}
