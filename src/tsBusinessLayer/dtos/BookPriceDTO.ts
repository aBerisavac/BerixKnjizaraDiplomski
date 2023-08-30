import {IBookPrice} from "../interfaces/IBookPrice"

export class BookPriceDTO implements IBookPrice{
    public id:number;
    public price:number;

    constructor(id:number, price: number){
        this.id = id;
        this.price = price;
    }
}