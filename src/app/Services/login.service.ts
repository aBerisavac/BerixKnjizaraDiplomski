import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  private userToken =
    'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiIxMDYzODY5Yi1mYTI1LTQ2YTAtOWE5ZC1kYmYwZTdjMmVhYjciLCJpc3MiOiJhc3BfYXBpIiwiaWF0IjoxNjkyODY0NjMyLCJVc2VySWQiOiIxIiwiQWN0b3JEYXRhIjoie1wiRW1haWxcIjpcImFkbWluQGFkbWluLmNvbVwiLFwiVXNlcklkXCI6MSxcIlJvbGVJZFwiOjEsXCJBbGxvd2VkVXNlQ2FzZXNcIjpbMSwyLDMsNCw1LDYsNyw4LDksMTAsMTEsMTIsMTMsMTQsMTUsMTYsMTcsMTgsMTksMjAsMjEsMjIsMjMsMjQsMjUsMjYsMjcsMjgsMjksMzAsMzEsMzIsMzMsMzQsMzUsMzYsMzcsMzgsMzksNDAsNDEsNDIsNDMsNDQsNDVdfSIsIm5iZiI6MTY5Mjg2NDYzMiwiZXhwIjoxNjkyOTUxMDMyLCJhdWQiOiJBbnkifQ.9_OaK1F5ra9sWvcfDGklIaejB1vrLuElnG1hlVm-Jas';

  private isLoggedIn: boolean = false;
  private loginService = new BehaviorSubject<boolean>(this.isLoggedIn);
  public isLoggedIn$ = this.loginService.asObservable();

  private errors: Array<string> = [];
  private loginErrors = new BehaviorSubject<Array<string>>(this.errors);
  public errors$ = this.loginErrors.asObservable();

  constructor(private http: HttpClient, private _router: Router) {}

  public tryLogin(email: String, password: String) {
    this.http
      .post<any>('http://localhost:5111/api/token', { email, password })
      .subscribe({
        next: (data) => {
          this.errors = [];
          this.userToken = data.token;
          this.isLoggedIn = true;
          this.errors = [];
          this._router.navigateByUrl('/');
          
          this.loginService.next(this.isLoggedIn);
        },
        error: (error) => {
          console.log('greska');
          this.errors = [];
          if (error.status == 401) {
            this.isLoggedIn = false;
            this.errors.push('Incorrect email or password. Please, try again.');
          } else {
            this.isLoggedIn = false;
            this.errors.push('There was an error. Try again later.');
          }
          this.loginService.next(this.isLoggedIn);
          this.loginErrors.next(this.errors);
        },
      });
  }

  public getToken() {
    return this.userToken;
  }

  public isAdminLoggedIn() {
    return this.isLoggedIn;
  }

  public logout() {
    this.loginService.next(false);
  }
}
