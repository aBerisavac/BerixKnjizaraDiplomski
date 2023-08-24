import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private userToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiIxMDYzODY5Yi1mYTI1LTQ2YTAtOWE5ZC1kYmYwZTdjMmVhYjciLCJpc3MiOiJhc3BfYXBpIiwiaWF0IjoxNjkyODY0NjMyLCJVc2VySWQiOiIxIiwiQWN0b3JEYXRhIjoie1wiRW1haWxcIjpcImFkbWluQGFkbWluLmNvbVwiLFwiVXNlcklkXCI6MSxcIlJvbGVJZFwiOjEsXCJBbGxvd2VkVXNlQ2FzZXNcIjpbMSwyLDMsNCw1LDYsNyw4LDksMTAsMTEsMTIsMTMsMTQsMTUsMTYsMTcsMTgsMTksMjAsMjEsMjIsMjMsMjQsMjUsMjYsMjcsMjgsMjksMzAsMzEsMzIsMzMsMzQsMzUsMzYsMzcsMzgsMzksNDAsNDEsNDIsNDMsNDQsNDVdfSIsIm5iZiI6MTY5Mjg2NDYzMiwiZXhwIjoxNjkyOTUxMDMyLCJhdWQiOiJBbnkifQ.9_OaK1F5ra9sWvcfDGklIaejB1vrLuElnG1hlVm-Jas";
  private isLoggedIn: boolean = false;
  // private isLoggedIn: boolean = true;
  private loginService = new BehaviorSubject<boolean>(this.isLoggedIn);
  public isLoggedIn$ = this.loginService.asObservable();

  constructor(private http: HttpClient) {  }

  public tryLogin(email:String, password: String){
    this.http.post<any>('http://localhost:5111/api/token', {email, password}).subscribe(
      {
        next: data => {
            this.userToken = data.token;
            this.isLoggedIn = true;
        },
        error: error => {
            console.error('There was an error!', error);
            this.isLoggedIn = false;
        }
    })

    this.loginService.next(this.isLoggedIn);
  }

  public isAdminLoggedIn(){
    return this.isLoggedIn;
  }

  public logout(){
    this.loginService.next(false);
  }


}
