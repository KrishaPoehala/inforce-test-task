import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/store';
import { deleteShortUrl, loadDescription, loadUrls } from '../resources/state/short-urls.actions';
import { ShortUrl } from '../resources/models/shortUrl.model';
import { allUrlsSelector } from '../resources/state/short-urls.selectors';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddShortUrlComponent } from '../add-short-url/add-short-url.component';
import { JwtTokenService } from '../../auth/resources/services/jwt-token.service';
import { Overlay, OverlayRef } from '@angular/cdk/overlay';
import { ComponentPortal } from '@angular/cdk/portal';
import { UserModel } from '../../auth/resources/models/userModel.model';
import { currentUserSelector, isAdmin } from '../../auth/resources/state/auth.selectors';
import { loadCurrentUser } from '../../auth/resources/state/auth.actions';
import { AlgorithmDescriptionComponent } from '../algorithm-description/algorithm-description.component';
import { ShortUrlDetailsComponent } from '../short-url-details/short-url-details.component';

@Component({
  selector: 'app-short-urls-container',
  templateUrl: './short-urls-container.component.html',
  styleUrls: ['./short-urls-container.component.css']
})
export class ShortUrlsContainerComponent implements OnInit {
  constructor(private store:Store<AppState>,private modal:NgbModal,
    readonly jwtService:JwtTokenService,readonly router:Router){
  }
  
  allUrls$!:Observable<ShortUrl[]>
  currentUser$!:Observable<UserModel | null>;
  isAdmin$!:Observable<boolean>;
  ngOnInit(): void {
    this.store.dispatch(loadCurrentUser())
    this.store.dispatch(loadDescription())
    this.store.dispatch(loadUrls());
    this.allUrls$ = this.store.select(allUrlsSelector);
    this.currentUser$ = this.store.select(currentUserSelector);
    this.isAdmin$ = this.store.select(isAdmin);
  }

  onAddUrl(){
    this.modal.open(AddShortUrlComponent);
  }

  onUrlDelete(id:string){
    this.store.dispatch(deleteShortUrl({id:id}));
  }

  onDescription(){
    this.modal.open(AlgorithmDescriptionComponent)
  }

  onShowDetails(event:any,shortUrl:ShortUrl){
    if(event.target.id === 'delete-button'){
      return;
    }

    const ref = this.modal.open(ShortUrlDetailsComponent);
    ref.componentInstance.shortUrl = shortUrl;
  }

  
}
