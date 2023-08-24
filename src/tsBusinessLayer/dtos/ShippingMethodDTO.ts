import {IShippingMethod} from "../interfaces/IShippingMethod"

export class ShippingMethodDTO implements IShippingMethod{
    public id:number;
    public Name:String;
    public Cost:number;

    constructor(id:number, name: String, cost: number){
        this.id = id;
        this.Name = name;
        this.Cost = cost;
    }
}