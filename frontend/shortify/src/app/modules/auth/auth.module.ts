import { JwtHelperService } from '@auth0/angular-jwt';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { JWT_OPTIONS, JwtModule } from '@auth0/angular-jwt';
import { JwtTokenService } from './resources/services/jwt-token.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginService } from './resources/services/login.service';
import { EffectsModule } from '@ngrx/effects';
import { AuthEffects } from './resources/state/auth.effects';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from './resources/interceptors/jwt.interceptor';
import { RegisterComponent } from './register/register.component';



@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    EffectsModule.forFeature([AuthEffects])
  ],
  providers:[
    { provide:JWT_OPTIONS, useValue:JWT_OPTIONS },
    JwtHelperService,
    LoginService,
    { provide:HTTP_INTERCEPTORS, useClass:JwtInterceptor,multi:true }
  ]
})
export class AuthModule { }
