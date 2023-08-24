import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IHome } from '../Interfaces/IHome';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient) { }

  url: string = "assets/data/home.json";

  getHome() : Observable<IHome[]>{
    return this.http.get<IHome[]>(this.url);
  }
}
