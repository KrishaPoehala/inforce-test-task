import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { JwtTokenService } from "../services/jwt-token.service";
import { Router } from "@angular/router";


@Injectable()
export class JwtInterceptor implements HttpInterceptor{
    constructor(private jwt:JwtTokenService, private router:Router){

    }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if(this.jwt.isLoggedIn()){
            console.log(`Bearer ${this.jwt.getToken()}`);
            request = request.clone({
                setHeaders:{
                    Authorization:`Bearer ${this.jwt.getToken()}`
                }
            })
        }
        
        return next.handle(request);
        this.router.navigateByUrl('login');
        return throwError(() => new Error('Jwt token has expired'));

    }
}