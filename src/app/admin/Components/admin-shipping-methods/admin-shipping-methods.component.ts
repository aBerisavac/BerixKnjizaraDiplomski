import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IShippingMethodAdmin } from 'src/app/Interfaces/IShippingMethodAdmin';
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

  constructor(
    private _errorModalService: ErrorModalService, 
    private _shippingMethodsService: ShippingMethodsService,
    private _router: Router
    ){
  }

  ngOnInit(): void {
    this._shippingMethodsService.shippingMethods$.subscribe(x=>this.convertShippingMethodDTOToIShippingMethods(x))
  }

  convertShippingMethodDTOToIShippingMethods(shippingMethods: Array<ShippingMethodDTO>){
    this.jsonObjectArrayToDisplay = [];
    for (let shippingMethod of shippingMethods) {
      this.jsonObjectArrayToDisplay.push({
        id: shippingMethod.id,
        Name: shippingMethod.Name,
        Cost: shippingMethod.Cost
      } as IShippingMethodAdmin);
    }
  }

  editItem(item: ShippingMethodDTO){
    this._router.navigateByUrl(`${this._router.url}/edit/${item.id}`)
  }

  deleteItem(item: ShippingMethodDTO){
    this._shippingMethodsService.deleteShippingMethod(item.id);
  }
}
