declare var require: any;

import { ShippingMethodDTO } from '../dtos/ShippingMethodDTO';
import { IEntityGet } from '../interfaces/common/IEntityGet';
import { IEntityGetAll } from '../interfaces/common/IEntityGetAll';
import { TShippingMethodJson } from '../types/JSON/TShippingMethodJson';

export class ShippingMethodModel implements IEntityGetAll, IEntityGet {
  private shippingMethods: Array<ShippingMethodDTO> = [];

  constructor() {
    if (localStorage.getItem('ShippingMethods') == undefined) {
      let shippingMethods: Array<TShippingMethodJson> = require('src/assets/data/shippingMethod.json');
      this.shippingMethods =
        this.convertShippingMethodFromJsonToDTO(shippingMethods);
      localStorage.setItem(
        'ShippingMethods',
        JSON.stringify(this.shippingMethods)
      );
    } else {
      this.shippingMethods = JSON.parse(
        localStorage.getItem('ShippingMethods')!
      );
    }
  }

  public getAll<ShippingMethodDTO>(): Array<ShippingMethodDTO> {
    return this.shippingMethods as Array<ShippingMethodDTO>;
  }

  public get<ShippingMethodDTO>(id: number): ShippingMethodDTO {
    return this.shippingMethods.filter(
      (x) => x.id == id
    )[0] as ShippingMethodDTO;
  }

  private getMaxId(){
    let maxId = this.shippingMethods.sort((x,y)=>y.id-x.id)[0].id;
    this.shippingMethods.sort((x,y)=>x.id-y.id)[0].id
    return maxId;
  }

  public deleteItem(id: number) {
      let helpingArray: Array<ShippingMethodDTO> = [];
      for (let shippingMethod of this.shippingMethods) {
        if (shippingMethod.id != id) {
          helpingArray.push(shippingMethod);
        }
      }

      this.shippingMethods = helpingArray;

      localStorage.setItem(
        'ShippingMethods',
        JSON.stringify(this.shippingMethods)
      );
  }

  public insertShippingMethod(name: String, cost: Number){
    this.shippingMethods.push({
      "id": this.getMaxId()+1,
      "Cost": cost,
      "Name": name,
    } as ShippingMethodDTO)

    localStorage.setItem(
      'ShippingMethods',
      JSON.stringify(this.shippingMethods)
    );
  }

  private convertShippingMethodFromJsonToDTO(
    shippingMethods: Array<TShippingMethodJson>
  ): Array<ShippingMethodDTO> {
    let shippingMethodsDTO: Array<ShippingMethodDTO> = [];
    for (let shippingMethod of shippingMethods) {
      shippingMethodsDTO.push({
        id: shippingMethod.id,
        Cost: shippingMethod.Cost,
        Name: shippingMethod.Name,
      });
    }

    return shippingMethodsDTO;
  }
}
