import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CartService } from 'src/app/Services/cart.service';
import { LoginService } from 'src/app/Services/login.service';
import { UsersService } from 'src/app/Services/users.service';
import { plainToClass, plainToInstance } from 'class-transformer';
import { UserDTO } from 'src/tsBusinessLayer/dtos/UserDTO';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss'],
})
export class NavigationComponent implements OnInit {
  public totalBooksInCart = 0;
  public showAdminButton = false;
  public isLoggedIn = false;
  public isAdminLoggedIn = false;

  constructor(
    private _cartService: CartService,
    private _loginService: LoginService,
    public router: Router,
    private _usersService: UsersService
  ) {
    this._loginService.isLoggedIn$.subscribe((x) => {
      this.isLoggedIn = x;
    });
  }

  ngOnInit(): void {
    this._cartService.currentDataCart$.subscribe((x) => {
      if (x.length > 0) {
        this.totalBooksInCart = x.reduce(
          (sum, current) => sum + current.Quantity,
          0
        );
      } else {
        this.totalBooksInCart = 0;
      }
    });

    this._usersService.loggedInUserData$.subscribe((x) => {
      if (x == undefined) {
        this.isAdminLoggedIn = false;
      } else if (x.Role == undefined) {
        this.isAdminLoggedIn = false;
      } else if (x!.Role!.id == 1) {
        this.isAdminLoggedIn = true;
      }
    });
  }
}
