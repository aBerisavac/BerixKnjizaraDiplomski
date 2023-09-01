import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { VALIDATORS } from 'common';
import { IBookCart } from 'src/app/Interfaces/IBookCart';
import { CartService } from 'src/app/Services/cart.service';
import { ErrorModalService } from 'src/app/Services/error-modal.service';
import { ShippingMethodsService } from 'src/app/Services/shipping-methods.service';
import { UsersService } from 'src/app/Services/users.service';
import { ShippingMethodDTO } from 'src/tsBusinessLayer/dtos/ShippingMethodDTO';

@Component({
  selector: 'app-checkout-dialog',
  templateUrl: './checkout-dialog.component.html',
  styleUrls: ['./checkout-dialog.component.scss'],
})
export class CheckoutDialogComponent implements OnInit {
  @Output() closeDialog = new EventEmitter<any>();
  @Output() successfullCheckout = new EventEmitter<FormData>();

  public shippingMethods: Array<ShippingMethodDTO> = [];
  public totalCost = 0;
  public itemsInCart: IBookCart[] = [];

  public selectedShippingMethod: ShippingMethodDTO;

  constructor(
    private _errorModal: ErrorModalService,
    private _cartService: CartService,
    private _shippingMethodsService: ShippingMethodsService
  ) {
    this.shippingMethods = this._shippingMethodsService.getShippingMethods();
    this.selectedShippingMethod = this.shippingMethods[0];
  }

  public setShippingMethod(e: Event) {
    this.selectedShippingMethod = this.shippingMethods.filter(
      (x) => x.id == parseInt((e.target as HTMLInputElement).value)
    )[0];
  }

  public checkout() {
    let formData: FormData = new FormData(document.createElement('form'));
    formData = this.appendUserData(formData);
    formData = this.appendCartData(formData);
    formData.append(
      'ShippingMethod',
      JSON.stringify(this.selectedShippingMethod)
    );

    if (this.validateData()) {
      this._cartService.removeAllElements();
      this.successfullCheckout.emit(formData);
    }
  }

  public validateData() {
    let errors: Array<String> = [];

    if (errors.length > 0) {
      this._errorModal.setErrors(errors);
      return false;
    } else {
      return true;
    }
  }

  public appendUserData(formData: FormData) {
    // formData.set('Address', this.userAddress);

    return formData;
  }

  public appendCartData(formData: FormData) {
    let cart: any = [];
    let i = 0;
    for (let item of this.itemsInCart) {
      cart.push(item);
    }
    formData.append('items', JSON.stringify(cart));
    return formData;
  }

  ngOnInit(): void {
    this._cartService.currentDataCart$.subscribe((x) => {
      if (x) {
        this.itemsInCart = x;
        this.totalCost = x.reduce(
          (sum, current) => sum + current.Prices[0].price * current.Quantity,
          0
        );
      }
    });
  }
}
