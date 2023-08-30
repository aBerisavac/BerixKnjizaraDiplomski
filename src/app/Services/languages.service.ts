import { Injectable } from '@angular/core';
import { LanguageModel } from 'src/tsBusinessLayer/Models/LanguageModel';
import { LanguageDTO } from 'src/tsBusinessLayer/dtos/LanguageDTO';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, catchError, of } from 'rxjs';
import { capitalizePropertyNamesWithoutIdCapitalization } from 'common';

@Injectable({
  providedIn: 'root'
})
export class LanguagesService {

  constructor(private _http: HttpClient) { }

  private languages = new BehaviorSubject<Array<LanguageDTO>>([]);
  public languages$ = this.languages.asObservable();

  private languageModel = new LanguageModel();

  getLanguages(): LanguageDTO[] {
    this._http
    .get<any>('http://localhost:5000/api/language')
    .pipe(catchError((error: any, caught: Observable<any>): Observable<any> => {
      console.log(error)

      return of();
  }))
    .subscribe({
      next: (data) => {
        let languagesFromBack: LanguageDTO[] = [];
        for(let language of data){
          languagesFromBack.push(capitalizePropertyNamesWithoutIdCapitalization(language) as LanguageDTO);
        }

        this.languages.next(languagesFromBack)
      }
    });

    return this.languageModel.getAll();
  }

  getLanguage(id: number): LanguageDTO {
    return this.languageModel.get(id);
  }

}
