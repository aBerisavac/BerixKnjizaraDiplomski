import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { LoginService } from 'src/app/Services/login.service';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  public errors: Array<string> = [];

  constructor(private _loginService: LoginService) {}

  @ViewChild('passwordInput') passwordInput: ElementRef | undefined;
  @ViewChild('emailInput') emailInput: ElementRef | undefined;

  ngOnInit(): void {
      this._loginService.errors$.subscribe(x=>{
        this.errors=x;
      })
  }

  public login() {
    let password = this.passwordInput!.nativeElement.value;
    let email = this.emailInput!.nativeElement.value;
    if (
      password != undefined &&
      password.trim() != '' &&
      email != undefined &&
      email.trim() != ''
    ) {
      this._loginService.tryLogin(email.trim(), password.trim());
    } else {
      this.errors = [];
      this.errors.push('You need to enter both email and password.');
    }
  }

  public ifEnterIsPressedTryLogin(event: KeyboardEvent){
    if (event.key === "Enter") {
      this.login();
    }
  }
}
