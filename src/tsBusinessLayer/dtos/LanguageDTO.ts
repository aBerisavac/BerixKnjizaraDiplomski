import {ILanguage} from "../interfaces/ILanguage"

export class LanguageDTO implements ILanguage{
    public id:number;
    public Name:String;

    constructor(id:number, name: String){
        this.id = id;
        this.Name = name;
    }
}