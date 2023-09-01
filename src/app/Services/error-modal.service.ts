import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ErrorModalService {

  public errors: Array<String> = [];
  private errorModal = new BehaviorSubject<Array<String>>(this.errors);
  public errors$ = this.errorModal.asObservable();

  public setErrors(errors: Array<String>){
    this.errorModal.next(errors);
    console.log(errors)
  }
}
