import { Component, OnInit, Renderer2, ViewChild } from '@angular/core';
import { CartService } from 'src/app/Services/cart.service';
import { LoginService } from 'src/app/Services/login.service';
import { UsersService } from 'src/app/Services/users.service';

@Component({
  selector: 'app-popup-bottom-right',
  templateUrl: './popup-bottom-right.component.html',
  styleUrls: ['./popup-bottom-right.component.scss']
})
export class PopupBottomRightComponent implements OnInit {
  public showComponent = false;
  public message = "";
  private timerId: any;

  constructor(private _cartService: CartService, private _userService: UsersService, private _loginService: LoginService){ 
    this.showComponent=false;
  }
  ngOnInit(): void {

    this._cartService.currentNotifyMessage$.subscribe(x=>{
      if(x){
        this.showComponent = true;

        //set style
        setTimeout(()=>{
          (document.querySelector("#popup-bottom-right") as HTMLDivElement).style.opacity = "1";
        }, 0)

        this.cancelTimeout();
        this.startTimeout();

        this.message = x as string;
      }
    })
    
    this._userService.currentNotifyMessage$.subscribe(x=>{
      if(x){
        this.showComponent = true;

        //set style
        setTimeout(()=>{
          (document.querySelector("#popup-bottom-right") as HTMLDivElement).style.opacity = "1";
        }, 0)

        this.cancelTimeout();
        this.startTimeout();

        this.message = x as string;
      }
    })
    
    this._loginService.currentNotifyMessage$.subscribe(x=>{
      if(x){
        this.showComponent = true;

        //set style
        this.cancelTimeout();
        setTimeout(()=>{
          (document.querySelector("#popup-bottom-right") as HTMLDivElement).style.opacity = "1";
        }, 0)

       this.startTimeout();

        this.message = x as string;
      }
    })
  }

  ngAfterViewInit(){

  }

  public closePopup(){
    (document.querySelector("#popup-bottom-right") as HTMLDivElement).style.opacity = "0";
    this.cancelTimeout();
    setTimeout(()=>{
    this.showComponent=false;
    this.message = ""
    }, 300)
  }

  startTimeout() {
    this.timerId = setTimeout(() => {
      // Your code to execute after the delay
      (document.querySelector("#popup-bottom-right") as HTMLDivElement).style.opacity = "0";
    }, 3500); // 2000 milliseconds delay (adjust as needed)
  }

  cancelTimeout() {
    clearTimeout(this.timerId); // Cancels the timeout
  }
}
