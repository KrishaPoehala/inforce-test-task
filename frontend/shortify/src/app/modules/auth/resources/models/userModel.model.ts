import { Roles } from "../enums/roles.enum";


export interface UserModel{
    id:string,
    email:string,
    name:string,
    role:Roles,
}