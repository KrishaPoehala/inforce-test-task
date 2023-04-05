import { Component, OnInit } from '@angular/core';
import { Observable, firstValueFrom } from 'rxjs';
import { Description } from '../resources/models/description.model';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/store';
import { descriptionSelector } from '../resources/state/short-urls.selectors';
import { editDescription } from '../resources/state/short-urls.actions';
import { JwtTokenService } from '../../auth/resources/services/jwt-token.service';
import { isAdmin } from '../../auth/resources/state/auth.selectors';

@Component({
  selector: 'app-algorithm-description',
  templateUrl: './algorithm-description.component.html',
  styleUrls: ['./algorithm-description.component.css']
})
export class AlgorithmDescriptionComponent implements OnInit{
  constructor(private store:Store<AppState>, readonly jwt:JwtTokenService)
  {}

  async ngOnInit() {
    this.description$ = this.store.select(descriptionSelector);
    this.isAdmin$ = this.store.select(isAdmin);
    this.value = (await firstValueFrom(this.description$))?.description!;
  }

  description$!:Observable<Description | null>;
  isAdmin$!:Observable<boolean>;
  isEditingMode = false;
  value!:string;
  onEdit(){
    if(this.isEditingMode){
      this.store.dispatch(editDescription({newDescription:this.value!}));
    }

    this.isEditingMode = !this.isEditingMode;
  }

  onEditDescription(){
    this.store.dispatch(editDescription({newDescription:this.value!}));
    this.isEditingMode = !this.isEditingMode;
  }
}
