import { addingNewUrlSelector, errorsSelector } from './../resources/state/short-urls.selectors';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/store';
import { createShortUrl } from '../resources/state/short-urls.actions';
import { Observable } from 'rxjs';
import { AbstractControl, ValidatorFn } from "@angular/forms";

@Component({
  selector: 'app-add-short-url',
  templateUrl: './add-short-url.component.html',
  styleUrls: ['./add-short-url.component.css']
})
export class AddShortUrlComponent implements OnInit {
  constructor(private fb:FormBuilder, private store:Store<AppState>){

  }
  ngOnInit(): void {
    this.errors$ = this.store.select(errorsSelector);
    this.addingNewUrl$ = this.store.select(addingNewUrlSelector);
  }

  shortUrlForm = this.fb.group({
    shortUrl:['',[Validators.required,this.urlValidator()]],
  })

  onSubmit(){
    if(this.shortUrlForm.invalid){
      return;
    }

    const value = this.shortUrlForm.controls.shortUrl.value!;
    this.store.dispatch(createShortUrl({originalUrl:value}));
  }

  errors$!:Observable<string[]>;
  addingNewUrl$!:Observable<boolean>;


  urlValidator(): ValidatorFn {
    const urlPattern = /^http(s?):\/\//i;
    return (control: AbstractControl): { [key: string]: any } | null => {
      const value = control.value;
      if (value && !urlPattern.test(value)) {
        return { 'invalidUrl': true };
      }
      return null;
    };
  }
}
