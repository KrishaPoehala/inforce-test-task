import { JwtTokenService } from './../services/jwt-token.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginGuard {
  constructor(private tokenService: JwtTokenService, private router:Router){
  }

  canActivate()
  : Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
     if(this.tokenService.isLoggedIn()){
      return true;
     }

     this.router.navigateByUrl('login');
     return false;
  }
  
}
