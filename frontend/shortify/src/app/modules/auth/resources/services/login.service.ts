import { HttpService } from "src/app/core/services/http.service";
import { LoginUserModel } from "../models/loginUser.model";
import { AuthResultModel } from "../models/authResult.model";
import { UserModel } from "../models/userModel.model";
import { Injectable } from "@angular/core";
import { RegisterUser } from "../models/registerUser.model";

@Injectable({
    providedIn:'root',
})
export class LoginService{
    constructor(private http:HttpService){
    }
    
    loginUser(model:LoginUserModel){
        return this.http.post<AuthResultModel>('auth/login', model);
    }
    
    registerUser(model: RegisterUser) {
        return this.http.post<AuthResultModel>('auth/register',model);
    }

    getUserById(id:string){
        return this.http.get<UserModel>(`users/get-by-id/${id}`);
    }
}