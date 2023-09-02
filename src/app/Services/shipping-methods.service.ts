import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { capitalizePropertyNamesWithoutIdCapitalization } from 'common';
import { BehaviorSubject, Observable, catchError, of } from 'rxjs';
import { ShippingMethodDTO } from 'src/tsBusinessLayer/dtos/ShippingMethodDTO';
import { UsersService } from './users.service';
import { ErrorModalService } from './error-modal.service';

@Injectable({
  providedIn: 'root',
})
export class ShippingMethodsService {
  constructor(
    private _http: HttpClient,
    private _userService: UsersService,
    private _errorModalService: ErrorModalService
  ) {}

  private shippingMethods = new BehaviorSubject<Array<ShippingMethodDTO>>([]);
  public shippingMethods$ = this.shippingMethods.asObservable();


  getShippingMethods(){
    this._http
      .get<any>('http://localhost:5000/api/shippingMethod')
      .pipe(
        catchError((error: any, caught: Observable<any>): Observable<any> => {
          console.log(error);

          return of();
        })
      )
      .subscribe({
        next: (data) => {
          let shippingMethodsFromBack: ShippingMethodDTO[] = [];
          for (let shippingMethod of data) {
            shippingMethodsFromBack.push(
              capitalizePropertyNamesWithoutIdCapitalization(
                shippingMethod
              ) as ShippingMethodDTO
            );
          }
          this.shippingMethods.next(shippingMethodsFromBack);
        },
      });
  }

  getShippingMethod(id: number): ShippingMethodDTO {
    return this.shippingMethods.getValue().filter(x=>x.id==id)[0]
  }

  insertShippingMethod(name: String, cost: Number) {
    const headers = {
      Authorization: `Bearer ${this._userService.getUserToken()}`,
    };
    this._http
      .post<any>(
        'http://localhost:5000/api/shippingMethod',
        { Name: name, Cost: cost },
        { headers }
      )
      .pipe(
        catchError((error: any, caught: Observable<any>): Observable<any> => {
          console.log(error);
          this._errorModalService.setErrors([error.error.message]);

          return of();
        })
      )
      .subscribe({
        next: (data) => {
          this.getShippingMethods();
        },
      });
  }

  editShippingMethod(shippingMethod: ShippingMethodDTO) {
    const headers = {
      Authorization: `Bearer ${this._userService.getUserToken()}`,
    };
    this._http
      .put<any>(
        `http://localhost:5000/api/shippingMethod/${shippingMethod.id}`,
        { Name: shippingMethod.Name, Cost: shippingMethod.Cost },
        { headers }
      )
      .pipe(
        catchError((error: any, caught: Observable<any>): Observable<any> => {
          console.log(error);
          this._errorModalService.setErrors([error.error.message]);

          return of();
        })
      )
      .subscribe({
        next: (data) => {
          this.getShippingMethods();
        },
      });
  }

  deleteShippingMethod(id: number) {
    const headers = {
      Authorization: `Bearer ${this._userService.getUserToken()}`,
    };
    this._http
      .delete<any>(`http://localhost:5000/api/shippingMethod/${id}`, {
        headers,
      })
      .pipe(
        catchError((error: any, caught: Observable<any>): Observable<any> => {
          this._errorModalService.setErrors([error.error.message]);

          return of();
        })
      )
      .subscribe({
        next: (data) => {
          this.getShippingMethods();
        },
      });
  }
}
