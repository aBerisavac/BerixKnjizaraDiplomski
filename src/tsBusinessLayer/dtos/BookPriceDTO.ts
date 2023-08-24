import {IBookPrice} from "../interfaces/IBookPrice"

export class BookPriceDTO implements IBookPrice{
    public id:number;
    public Price:number;
    public CreatedAt:Date;

    constructor(id:number, price: number, createdAt: Date){
        this.id = id;
        this.Price = price;
        this.CreatedAt = createdAt;
    }
}