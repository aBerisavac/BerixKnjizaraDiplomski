import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HomeService } from 'src/app/Services/home.service';
import { LanguagesService } from 'src/app/Services/languages.service';
import { HomeParagraphDTO } from 'src/tsBusinessLayer/dtos/HomeParagraphDTO';
import { LanguageDTO } from 'src/tsBusinessLayer/dtos/LanguageDTO';

@Component({
  selector: 'app-admin-home-paragraphs',
  templateUrl: './admin-home-paragraphs.component.html',
  styleUrls: ['./admin-home-paragraphs.component.scss']
})
export class AdminHomeParagraphsComponent implements OnInit {

  public jsonObjectArrayToDisplay: Array<HomeParagraphDTO> = [];

  constructor(
    private _homeService: HomeService, 
    private _router: Router, 
    ){
  }
  ngOnInit(): void {
    this._homeService.homeParagraphs$.subscribe(x=>this.jsonObjectArrayToDisplay = x);
  }

  editItem(item: HomeParagraphDTO){
    this._router.navigateByUrl(`${this._router.url}/edit/${item.id}`)
  }

  deleteItem(item: HomeParagraphDTO){
    this._homeService.deleteHomeParagraph(item.id)

  }
}
