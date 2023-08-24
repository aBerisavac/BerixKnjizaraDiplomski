import { Component, OnInit, Renderer2, ViewChild } from '@angular/core';
import { CartService } from 'src/app/Services/cart.service';

@Component({
  selector: 'app-popup-bottom-right',
  templateUrl: './popup-bottom-right.component.html',
  styleUrls: ['./popup-bottom-right.component.scss']
})
export class PopupBottomRightComponent implements OnInit {
  public showComponent = false;
  public message = "";

  constructor(private _cartService: CartService, private renderer: Renderer2){ 
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

        setTimeout(()=>{
          (document.querySelector("#popup-bottom-right") as HTMLDivElement).style.opacity = "0";
        }, 3500)

        this.message = x as string;
      }
    })
  }

  ngAfterViewInit(){

  }

  public closePopup(){
    (document.querySelector("#popup-bottom-right") as HTMLDivElement).style.opacity = "0";
    setTimeout(()=>{
    this.showComponent=false;
    this.message = ""
    }, 300)
  }

}
