import { Component, OnInit } from '@angular/core';
import { ErrorModalService } from 'src/app/Services/error-modal.service';
import { ShippingMethodsService } from 'src/app/Services/shipping-methods.service';
import { ShippingMethodDTO } from 'src/tsBusinessLayer/dtos/ShippingMethodDTO';

@Component({
  selector: 'app-admin-shipping-methods',
  templateUrl: './admin-shipping-methods.component.html',
  styleUrls: ['./admin-shipping-methods.component.scss']
})
export class AdminShippingMethodsComponent implements OnInit {
  public jsonObjectArrayToDisplay: Array<ShippingMethodDTO> = [];

  constructor(private _errorModalService: ErrorModalService, private _shippingMethodsService: ShippingMethodsService){
  }

  ngOnInit(): void {
    this.jsonObjectArrayToDisplay = this._shippingMethodsService.getShippingMethods() as Array<ShippingMethodDTO>;
  }

  editItem(item: ShippingMethodDTO){
    console.log(item)
  }

  deleteItem(item: ShippingMethodDTO){
    let errors = this._shippingMethodsService.deleteShippingMethod(item.id);
    if(errors.length>0){
      this._errorModalService.setErrors(errors);
    } else{
      this.jsonObjectArrayToDisplay = this._shippingMethodsService.getShippingMethods() as Array<ShippingMethodDTO>;
    }
  }
}
