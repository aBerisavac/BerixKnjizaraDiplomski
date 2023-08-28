import {IUserInsert} from "../interfaces/IUserInsert"

export class UserInsertDTO implements IUserInsert{
    public FirstName:String;
    public LastName:String;
    public Email:String;
    public Address:String;
    public Password: String;

    constructor(firstName: String, lastName: String, email: String, address: String, password: String){
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Address = address;
        this.Password = password;
    }
}