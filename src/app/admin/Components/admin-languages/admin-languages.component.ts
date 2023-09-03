import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LanguagesService } from 'src/app/Services/languages.service';
import { LanguageDTO } from 'src/tsBusinessLayer/dtos/LanguageDTO';

@Component({
  selector: 'app-admin-languages',
  templateUrl: './admin-languages.component.html',
  styleUrls: ['./admin-languages.component.scss']
})
export class AdminLanguagesComponent implements OnInit {
  public jsonObjectArrayToDisplay: Array<LanguageDTO> = [];

  constructor(
    private _languagesService: LanguagesService, 
    private _router: Router, 
    ){
  }
  ngOnInit(): void {
    this._languagesService.languages$.subscribe(x=>this.jsonObjectArrayToDisplay = x);
  }

  editItem(item: LanguageDTO){
    this._router.navigateByUrl(`${this._router.url}/edit/${item.id}`)
  }

  deleteItem(item: LanguageDTO){
    this._languagesService.deleteLanguage(item.id)
  }
}
