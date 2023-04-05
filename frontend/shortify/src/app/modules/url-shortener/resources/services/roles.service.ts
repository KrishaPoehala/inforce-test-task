import { Injectable } from '@angular/core';
import { JwtTokenService } from 'src/app/modules/auth/resources/services/jwt-token.service';



@Injectable()
export class RolesService{
    constructor(private jwt:JwtTokenService){

    }

    
}