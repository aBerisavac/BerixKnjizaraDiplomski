import {IUser} from "../interfaces/IUser"

export class UserDTO implements IUser{
    public id:number;
    public FirstName:String;
    public LastName:String;
    public Email:String;
    public Address:String;

    constructor(id:number, firstName: String, lastName: String, email: String, address: String){
        this.id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Address = address;
    }
}