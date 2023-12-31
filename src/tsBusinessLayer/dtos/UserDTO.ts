import {IUser} from "../interfaces/IUser"

export class UserDTO implements IUser{
    public id:number;
    public FirstName:String;
    public LastName:String;
    public Email:String;
    public Address:String;
    public Password: String;
    public Role: { id: number; Name: string; } | undefined;

    constructor(id:number, firstName: String, lastName: String, email: String, address: String, password: String){
        this.id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Address = address;
        this.Password = password;
    }
}