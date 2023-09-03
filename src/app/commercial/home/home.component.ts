import { Component, OnInit } from '@angular/core';
import { HomeService } from 'src/app/Services/home.service';
import { HomeParagraphDTO } from 'src/tsBusinessLayer/dtos/HomeParagraphDTO';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  paragraphs:HomeParagraphDTO[] = [];
  constructor(private homeService: HomeService) { }

  ngOnInit(): void {
    this.homeService.homeParagraphs$.subscribe(x=>{
      this.paragraphs=x;
    })
  }

}