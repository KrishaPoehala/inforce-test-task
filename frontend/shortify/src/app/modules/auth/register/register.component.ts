import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/store';
import { registerUser } from '../resources/state/auth.actions';
import { RegisterUser } from '../resources/models/registerUser.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  constructor(private fb:FormBuilder,private store:Store<AppState>)
  {}

  registerForm = this.fb.group({
    name:[''],
    email:[''],
    password:[''],
  })

  onSubmit(){
    if(this.registerForm.invalid){
      return;
    }

    const controls = this.registerForm.controls;
    const registerModel:RegisterUser = {
      name:controls.name.value!,
      email:controls.name.value!,
      password:controls.name.value!,
    }

    this.store.dispatch(registerUser({model:registerModel}));
  }
}
