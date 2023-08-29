import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { UsersService } from 'src/app/Services/users.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  public errors: Array<string> = [];

  constructor(private _userService: UsersService, private _router: Router) {}

  @ViewChild('firstNameInput') firstNameInput: ElementRef | undefined;
  @ViewChild('lastNameInput') lastNameInput: ElementRef | undefined;
  @ViewChild('emailInput') emailInput: ElementRef | undefined;
  @ViewChild('passwordInput') passwordInput: ElementRef | undefined;
  @ViewChild('addressInput') addressInput: ElementRef | undefined;

  ngOnInit(): void {
      this._userService.errors$.subscribe(x=>{
        this.errors = [];
        for(let error of x){
          this.errors.push(error.ErrorMessage as string);
        }
      })
  }

  public register() {
    let firstName = this.firstNameInput!.nativeElement.value.trim();
    let lastName = this.lastNameInput!.nativeElement.value.trim();
    let email = this.emailInput!.nativeElement.value.trim();
    let password = this.passwordInput!.nativeElement.value;
    let address = this.addressInput!.nativeElement.value.trim();

    if (
      password != undefined &&
      password != '' &&
      
      email != undefined &&
      email != '' &&

      firstName != undefined &&
      firstName != '' &&

      lastName != undefined &&
      lastName != '' &&

      address != undefined &&
      address != ''
    ) {
      this._userService.register(firstName, lastName, email, password, address);
    } else {
      this.errors = [];
      this.errors.push('You need to enter all of the information.');
    }
  }

}
