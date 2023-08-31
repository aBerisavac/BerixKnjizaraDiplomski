import { Component, OnInit } from '@angular/core';
import { HomeService } from 'src/app/Services/home.service';
import { IHome } from 'src/app/Interfaces/IHome';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  paragraphs:IHome[] = [];
  constructor(private homeService: HomeService) { }

  ngOnInit(): void {

    this.homeService.getHome().subscribe({
      next: data => {
        this.paragraphs = data;
      },
      error: err => {
        console.error(err)
      }
    })
  }

}