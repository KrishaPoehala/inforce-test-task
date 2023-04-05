import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/store';
import { LoginUserModel } from '../resources/models/loginUser.model';
import { loginUser } from '../resources/state/auth.actions';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private fb:FormBuilder, private store:Store<AppState>){

  }

  loginForm = this.fb.group({
    email: ['', [Validators.required]],
    password: ['', Validators.required]
  })

  onSubmit(){
    if(this.loginForm.invalid){
      return;
    }

    const model:LoginUserModel = {
      email:this.loginForm.controls.email.value!,
      password:this.loginForm.controls.password.value!,
    };

    this.store.dispatch(loginUser({request:model}));
  }
}
