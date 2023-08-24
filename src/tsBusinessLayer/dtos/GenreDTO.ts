import {IGenre} from "../interfaces/IGenre"

export class GenreDTO implements IGenre{
    public id:number;
    public Name:String;

    constructor(id:number, name: String){
        this.id = id;
        this.Name = name;
    }
}