import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, catchError, of } from 'rxjs';
import { UserModel } from 'src/tsBusinessLayer/Models/UserModel';
import { UserDTO } from 'src/tsBusinessLayer/dtos/UserDTO';
import { UserInsertDTO } from 'src/tsBusinessLayer/dtos/UserInsertDTO';
import {TErrorMessagesFromBack} from 'src/app/types/TErrorMessagesFromBack'
import { capitalizePropertyNamesWithoutIdCapitalization } from 'common';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  private userToken = "";
  private loggedInUser: UserDTO | undefined = undefined;
  private loggedInUserData = new BehaviorSubject<UserDTO | undefined>(undefined);
  public loggedInUserData$ = this.loggedInUserData.asObservable();

  private errors: Array<TErrorMessagesFromBack> = [];
  private loginErrors = new BehaviorSubject<Array<{PropertyName: String, ErrorMessage: String }>>(this.errors);
  public errors$ = this.loginErrors.asObservable();

  private notificationMessage = new BehaviorSubject<String>("")
  public currentNotifyMessage$ = this.notificationMessage.asObservable();

  constructor(private _http: HttpClient, private _router: Router) { }

  public register(firstName: string, lastName: string, email: string, password: string, address: string){
    let userToInsert = new UserInsertDTO(firstName, lastName, email, address, password);
    return this._http
      .post<any>('http://localhost:5000/api/user', userToInsert)
      .pipe(catchError((error: any, caught: Observable<any>): Observable<any> => {
        // this.errorMessage = error.message;
        let errors =  error.error.errors; 
        this.loginErrors.next(errors)

        return of();
    }))
      .subscribe({
        next: (data) => {
          this.errors = [];
          this._router.navigateByUrl('/login');
          this.notificationMessage.next("You have successfully registered");
        }
      });
  }

  setUserToken(newToken: string){
    this.userToken=newToken;

    if(newToken.trim()!=""){
      this.setUserData();
    }  else{
      this.loggedInUserData.next(undefined)
    }
  }
  
  private setUserData(){
    const headers = { 'Authorization': `Bearer ${this.getUserToken()}` };
    this._http.get<any>('http://localhost:5000/api/user', {headers})
    .subscribe(data => {
        this.loggedInUserData.next(capitalizePropertyNamesWithoutIdCapitalization(data[0]) as UserDTO);
        this.loggedInUser = capitalizePropertyNamesWithoutIdCapitalization(data[0]) as UserDTO;
    });
  }

  getUserToken(){
    return this.userToken;
  }

  public getUserData(){
    return this.loggedInUser;
  }
}
