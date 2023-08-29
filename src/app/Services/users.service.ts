import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, catchError, of } from 'rxjs';
import { UserModel } from 'src/tsBusinessLayer/Models/UserModel';
import { UserDTO } from 'src/tsBusinessLayer/dtos/UserDTO';
import { UserInsertDTO } from 'src/tsBusinessLayer/dtos/UserInsertDTO';
import {TErrorMessagesFromBack} from 'src/app/types/TErrorMessagesFromBack'

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
    let userToInsert = new UserInsertDTO(firstName, lastName, email, password, address);
    return this._http
      .post<any>('http://localhost:5111/api/user', userToInsert)
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

  

  private capitalizePropertyNames(obj: any) {
    const newObj: { [key: string]: any } = {};

    for (let key in obj) {
      if (key != 'id') {
        const capitalizedKey = key.charAt(0).toUpperCase() + key.slice(1);
        newObj[capitalizedKey] = obj[key];
      } else {
        const capitalizedKey = 'id';
        newObj[capitalizedKey] = obj[key];
      }
    }

    return newObj;
  }
  
  private setUserData(){
    const headers = { 'Authorization': `Bearer ${this.getUserToken()}` };
    this._http.get<any>('http://localhost:5111/api/user', {headers})
    .subscribe(data => {
        this.loggedInUserData.next(this.capitalizePropertyNames(data[0]) as UserDTO);
        this.loggedInUser = this.capitalizePropertyNames(data[0]) as UserDTO;
    });
  }

  getUserToken(){
    return this.userToken;
  }

  public getUserData(){
    return this.loggedInUser;
  }
}
