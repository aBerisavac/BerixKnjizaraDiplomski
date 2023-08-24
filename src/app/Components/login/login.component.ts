import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent  {
  constructor(
    private _loginService: LoginService,
  ) {}

  @ViewChild('passwordInput') passwordInput: ElementRef | undefined;
  @ViewChild('emailInput') emailInput: ElementRef | undefined;

  public login() {
    let password = this.passwordInput!.nativeElement.value;
    let email = this.emailInput!.nativeElement.value;
    if (
      password != undefined &&
      password != '' &&
      email != undefined &&
      email != ''
    ) {
      this._loginService.tryLogin(email, password);
    }
  }
}
