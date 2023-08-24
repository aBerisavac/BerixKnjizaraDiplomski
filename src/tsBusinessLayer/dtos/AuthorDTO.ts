import {IAuthor} from "../interfaces/IAuthor"

export class AuthorDTO implements IAuthor{
    public id:number;
    public FirstName:String;
    public LastName:String;
    public BirthDate:Date;

    constructor(id:number, firstName: String, lastName: String, birthDate: Date){
        this.id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.BirthDate = birthDate;
    }
}