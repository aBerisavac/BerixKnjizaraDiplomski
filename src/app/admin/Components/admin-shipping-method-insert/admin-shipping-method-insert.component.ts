import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { VALIDATORS, capitalizeFirstLetter } from 'common';
import { ErrorModalService } from 'src/app/Services/error-modal.service';
import { ShippingMethodsService } from 'src/app/Services/shipping-methods.service';

@Component({
  selector: 'app-admin-shipping-method-insert',
  templateUrl: './admin-shipping-method-insert.component.html',
  styleUrls: ['./admin-shipping-method-insert.component.scss'],
})
export class AdminShippingMethodInsertComponent {
  constructor(
    private _modalErrorService: ErrorModalService,
    private _shippingMethodService: ShippingMethodsService,
    private router: Router
  ) {}

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
      if (
        this._shippingMethodService.insertShippingMethod(
          capitalizeFirstLetter(shippingMethodName as string),
          parseFloat(shippingMethodCost as string)
        )
      ) {
        this.router.navigateByUrl('/admin/shipping_methods');
      } else {
        this._modalErrorService.setErrors([
          'There was an error storing data. Try again later.',
        ]);
      }
    }
  }
}
