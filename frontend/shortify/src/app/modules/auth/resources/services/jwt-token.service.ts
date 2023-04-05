import { Injectable } from "@angular/core";
import { JwtHelperService } from "@auth0/angular-jwt";

@Injectable({
    providedIn:'root'
})
export class JwtTokenService{
    constructor(private jwt: JwtHelperService){
    }
    accessTokenLocation = "accessToken";

    logIn(token:string){
        localStorage.setItem(this.accessTokenLocation, token);
    }

    logOut(){
        localStorage.removeItem(this.accessTokenLocation);
    }

    isLoggedIn(){
        const token = localStorage.getItem(this.accessTokenLocation);
        return token !== null && !this.jwt.isTokenExpired(token);
    }

    getUserIdFromToken(){
        const token = localStorage.getItem(this.accessTokenLocation);
        const decodedToken = this.jwt.decodeToken(token!);
        console.log(decodedToken);
        return decodedToken['id'];
    }

    getToken(){
        return localStorage.getItem(this.accessTokenLocation);
    }
}