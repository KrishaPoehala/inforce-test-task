import { Actions, createEffect, ofType } from "@ngrx/effects";
import { getUserSuccess, loadCurrentUser, loginUser, authUserFailure, authUserSuccess, registerUser } from "./auth.actions";
import { catchError, map, of, switchMap, tap } from "rxjs";
import { LoginService } from "../services/login.service";
import { JwtTokenService } from "../services/jwt-token.service";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";

@Injectable()
export class AuthEffects{
    constructor(private actions:Actions, private http:LoginService, 
        private jwtService:JwtTokenService, private router:Router){
    }

    loginUser$ = createEffect(() => 
        this.actions.pipe(
            ofType(loginUser),
            switchMap(action => this.http.loginUser(action.request)
            .pipe(
                map(result => authUserSuccess({authResult:result})),
                catchError(error => of(authUserFailure({errors:error})))
            ))
        )
    )

    registerUser$ = createEffect(() => 
        this.actions.pipe(
            ofType(registerUser),
            switchMap(action => {
                return this.http.registerUser(action.model).pipe(
                    map(result => authUserSuccess({authResult:result})),
                    catchError(error => of(authUserFailure({errors:error}))),
                )
            })
        )
    )

    getUser$ = createEffect(() => 
        this.actions.pipe(
            ofType(authUserSuccess),
            tap(result => this.jwtService.logIn(result.authResult.accessToken!)),
            switchMap(action => {
                const userId = this.jwtService.getUserIdFromToken();
                return this.http.getUserById(userId).pipe(
                    map(result => {
                        this.router.navigateByUrl('/')
                        return getUserSuccess({user:result});
                    })
                );
            })
        )
    )

    loadUser$ = createEffect(() => 
        this.actions.pipe(
            ofType(loadCurrentUser),
            switchMap(action => {
                const userId = this.jwtService.getUserIdFromToken();
                return this.http.getUserById(userId).pipe(
                    map(result => {
                        this.router.navigateByUrl('/')
                        return getUserSuccess({user:result});
                    })
                );
            })
        )
    )
}