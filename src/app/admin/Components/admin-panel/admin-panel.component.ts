import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/Services/login.service';
import { UsersService } from 'src/app/Services/users.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.scss'],
})
export class AdminPanelComponent implements OnInit {
  @ViewChild('buttonsHolder') buttonsHolder: any;
  private buttonInputs: Array<HTMLInputElement> = [];
  private router: Router;
  private insertButtonElement: HTMLAnchorElement = document.createElement('a');
  public isInsertable = false;

  constructor(
    router: Router,
    private _loginService: LoginService,
    private _userService: UsersService
  ) {
    this.router = router;
  }

  ngOnInit(): void {
   if (this._userService.getUserData()== undefined || this._userService.getUserData()!.Role!.id != 1)
        setTimeout(()=>this.router.navigateByUrl('/'), 1)
  }

  public addActiveClass = (e: MouseEvent) => {
    let clickedButton = e.currentTarget as HTMLInputElement;
    for (let button of this.buttonInputs) {
      if (button.classList.contains('active')) {
        button.classList.remove('active');
      }
    }
    clickedButton.classList.add('active');
    this.insertButtonElement.classList.remove('active');

    setTimeout(() => {
      this.checkIfEntityIsInsertable(window.location.href);
    }, 1);
  };

  public addActiveClassToInsertButton = (e: MouseEvent) => {
    this.insertButtonElement = e.currentTarget as HTMLAnchorElement;
    this.insertButtonElement.classList.add('active');
  };

  checkIfEntityIsInsertable(string: string) {
    if (string.indexOf('order') == -1) {
      this.isInsertable = true;
    } else {
      this.isInsertable = false;
    }
  }

  ngAfterViewInit() {
    this.buttonInputs = Array.from(
      (this.buttonsHolder.nativeElement as HTMLDivElement).querySelectorAll(
        'input'
      )
    ) as Array<HTMLInputElement>;
    this.buttonInputs[this.buttonInputs.length - 1].click();
  }

  getPath() {
    if(this.router.url.indexOf("insert")==-1){
      return this.router.url.slice(0, this.router.url.indexOf("edit") != -1 ? this.router.url.indexOf("edit"): this.router.url.length) + '/insert';
    } else {
      return this.router.url;
    }
  }
}
