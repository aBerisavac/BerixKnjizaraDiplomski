import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { VALIDATORS } from 'common';
import { IBookCart } from 'src/app/Interfaces/IBookCart';
import { CartService } from 'src/app/Services/cart.service';
import { ErrorModalService } from 'src/app/Services/error-modal.service';
import { ShippingMethodsService } from 'src/app/Services/shipping-methods.service';
import { ShippingMethodDTO } from 'src/tsBusinessLayer/dtos/ShippingMethodDTO';

@Component({
  selector: 'app-checkout-dialog',
  templateUrl: './checkout-dialog.component.html',
  styleUrls: ['./checkout-dialog.component.scss']
})
export class CheckoutDialogComponent implements OnInit {
  @Output() closeDialog = new EventEmitter<any>();
  @Output() successfullCheckout = new EventEmitter<FormData>();

  public shippingMethods: Array<ShippingMethodDTO> = []
  public totalCost = 0;
  public itemsInCart: IBookCart[] = [];

  public userFirstName = "";
  public userLastName = "";
  public userEmail = "";
  public userAddress = "";
  public selectedShippingMethod: ShippingMethodDTO;

  constructor( private _errorModal: ErrorModalService, private _cartService: CartService, private _shippingMethodsService: ShippingMethodsService){
    this.shippingMethods = this._shippingMethodsService.getShippingMethods();
    this.selectedShippingMethod = this.shippingMethods[0];
  }

  public setFirstName(e: Event){
    this.userFirstName = (e.target as HTMLInputElement).value;
  }

  public setLastName(e: Event){
    this.userLastName = (e.target as HTMLInputElement).value;
  }

  public setAddress(e: Event){
    this.userEmail = (e.target as HTMLInputElement).value;
  }

  public setEmail(e: Event){
    this.userAddress = (e.target as HTMLInputElement).value;
  }

  public setShippingMethod(e: Event){
    this.selectedShippingMethod = this.shippingMethods.filter(x=>x.id==parseInt((e.target as HTMLInputElement).value))[0]
  }

  public checkout(){
    let formData: FormData = new FormData(document.createElement("form"));
    formData = this.appendUserData(formData);
    formData = this.appendCartData(formData);
    formData.append("ShippingMethod", JSON.stringify(this.selectedShippingMethod))
 
    if(this.validateData()){
      this._cartService.removeAllElements()
      this.successfullCheckout.emit(formData);
    }
  }

  public validateData(){
    let errors:Array<String> = []
    
    if(!VALIDATORS.variableNotUndefined(this.userFirstName) || !VALIDATORS.stringNotNull(this.userFirstName)){
      errors.push("First name field must not be empty");
    }

    if(!VALIDATORS.variableNotUndefined(this.userLastName) || !VALIDATORS.stringNotNull(this.userLastName)){
      errors.push("Last name field must not be empty");
    }

    if(!VALIDATORS.variableNotUndefined(this.userEmail) || !VALIDATORS.stringNotNull(this.userEmail)){
      errors.push("Email field must not be empty");
    } else{
      if(!VALIDATORS.email(this.userEmail)){
        errors.push("Email is not in the correct format.")
      }
    }

    if(!VALIDATORS.variableNotUndefined(this.userAddress) || !VALIDATORS.stringNotNull(this.userAddress)){
      errors.push("Address field must not be empty");
    }

    if(errors.length>0){
      this._errorModal.setErrors(errors);
      return false;
    } else{
      return true;
    }
  }

  public appendUserData(formData: FormData){
    formData.set("FirstName", this.userFirstName);
    formData.set("LastName", this.userLastName);
    formData.set("Email", this.userEmail);
    formData.set("Address", this.userAddress);

    return formData;
  }

  public appendCartData(formData:FormData){
    let cart: any = []
    let i=0;
    for(let item of this.itemsInCart){
      cart.push(item);
    }
    formData.append("items", JSON.stringify(cart))
    return formData;
  }

  ngOnInit(): void {
    this._cartService.currentDataCart$.subscribe(x=>{
      if(x)
      {
        this.itemsInCart = x;
        this.totalCost = x.reduce((sum, current) => sum + (current.BookPrices[0].Price * current.Quantity), 0);
      }
    })
  }

}
