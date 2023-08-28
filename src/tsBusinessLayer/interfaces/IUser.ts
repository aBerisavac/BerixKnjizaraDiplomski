export interface IUser{
    "id": number,
    "FirstName": String,
    "LastName": String,
    "Email": String,
    "Address": String,
    "Password": String,
    "Role"?: {
        "id": number,
        "Name": string
    }
}