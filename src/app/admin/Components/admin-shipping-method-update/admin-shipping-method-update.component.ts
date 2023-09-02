import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { VALIDATORS, capitalizeFirstLetter } from 'common';
import { ErrorModalService } from 'src/app/Services/error-modal.service';
import { ShippingMethodsService } from 'src/app/Services/shipping-methods.service';
import { ShippingMethodDTO } from 'src/tsBusinessLayer/dtos/ShippingMethodDTO';

@Component({
  selector: 'app-admin-shipping-method-update',
  templateUrl: './admin-shipping-method-update.component.html',
  styleUrls: ['./admin-shipping-method-update.component.scss']
})
export class AdminShippingMethodUpdateComponent {
  public shippingMethodToEdit: ShippingMethodDTO;

  constructor(
    private _shippingMethodsService: ShippingMethodsService,
    private _modalErrorService: ErrorModalService,
    private _route: ActivatedRoute,
    private _router: Router
  ) {
    let id = parseInt(this._route.snapshot.paramMap.get('id')!);
    this.shippingMethodToEdit = _shippingMethodsService.getShippingMethod(id);
  }

  public formSubmitted(e: SubmitEvent) {
    e.preventDefault();
    const data = new FormData(e.target as HTMLFormElement);
    let shippingMethodName = data.get('name') as String;
    let shippingMethodCost = data.get('cost') as String;

    let errors: Array<String> = [];

    if (
      !VALIDATORS.variableNotUndefined(shippingMethodName) ||
      !VALIDATORS.stringNotNull(shippingMethodName)
    ) {
      errors.push("Shipping method name can't be empty.");
    }

    if (
      !VALIDATORS.variableNotUndefined(shippingMethodCost) ||
      !VALIDATORS.stringNotNull(shippingMethodCost)
    ) {
      errors.push("Shipping method cost can't be empty.");
    } else {
      if (!VALIDATORS.isNumber(shippingMethodCost as string)) {
        errors.push(
          "Shipping method cost can't be converted to number. Make sure you are using '.' for decimals."
        );
      } else {
        if (!VALIDATORS.min(shippingMethodCost as string, 0)) {
          errors.push('Shipping method cost must be a positive number.');
        }
      }
    }

    if (errors.length > 0) {
      this._modalErrorService.setErrors(errors);
    } else {
      this._shippingMethodsService.editShippingMethod(
        new ShippingMethodDTO(this.shippingMethodToEdit.id, capitalizeFirstLetter(shippingMethodName as string), parseInt(shippingMethodCost as string))
      );
      this._router.navigateByUrl('/admin/panel/shipping_methods');
    }
  }
}
