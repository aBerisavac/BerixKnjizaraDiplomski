import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { UsersService } from './users.service';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  private isLoggedInInitial: boolean = false;
  private isLoggedIn = new BehaviorSubject<boolean>(this.isLoggedInInitial);
  public isLoggedIn$ = this.isLoggedIn.asObservable();

  private errors: Array<string> = [];
  private loginErrors = new BehaviorSubject<Array<string>>(this.errors);
  public errors$ = this.loginErrors.asObservable();

  private notificationMessage = new BehaviorSubject<String>('');
  public currentNotifyMessage$ = this.notificationMessage.asObservable();

  constructor(
    private http: HttpClient,
    private _router: Router,
    private _userService: UsersService
  ) {
    if(localStorage.getItem("userToken")!=undefined && localStorage.getItem("userToken")!=""){
      this.isLoggedIn.next(true);
    }
  }

  public tryLogin(email: String, password: String) {
    this.http
      .post<any>('http://localhost:5000/api/token', { email, password })
      .subscribe({
        next: (data) => {
          this.errors = [];
          this._userService.setUserToken(data.token);
          this.errors = [];
          this._router.navigateByUrl('/');
          this.notificationMessage.next('You have successfully logged in.');
          this.isLoggedIn.next(true);
          this.loginErrors.next([]);
        },
        error: (error) => {
          this.errors = [];
          if (error.status == 401) {
            this.errors.push('Incorrect email or password. Please, try again.');
          } else {
            this.errors.push('There was an error. Try again later.');
          }
          this.isLoggedIn.next(false);
          this.loginErrors.next(this.errors);
        },
      });
  }

  public getToken() {
    return this._userService.getUserToken();
  }

  public logout() {
    localStorage.clear();
    this._userService.setUserToken('');
    this.isLoggedIn.next(false);
    this.notificationMessage.next("You have successfully logged out");
  }
}
