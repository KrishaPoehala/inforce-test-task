import { EffectsModule } from '@ngrx/effects';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { StoreModule } from '@ngrx/store';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { metaReducers, reducers } from './store';
import { AppRoutingModule } from './app.routing.module';
import { RouterModule } from '@angular/router';
import { UrlShortenerModule } from './modules/url-shortener/url-shortener.module';
import { AuthModule } from './modules/auth/auth.module';
import { HttpService } from './core/services/http.service';
import { AuthEffects } from './modules/auth/resources/state/auth.effects';
import { HttpClientModule } from '@angular/common/http';
import { ShortUrlsEffects } from './modules/url-shortener/resources/state/short-urls.effects';
import { NgbActiveModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    AppRoutingModule,
    RouterModule,
    AuthModule,
    HttpClientModule,
    BrowserModule,
    StoreModule.forRoot(reducers, {
      metaReducers,
      runtimeChecks: {
        strictActionWithinNgZone: true,
        strictActionTypeUniqueness: true,
        strictStateImmutability: false,
        strictActionImmutability: false,
      },
    }),
    EffectsModule.forRoot([
      AuthEffects,
      ShortUrlsEffects,
    ]),
    ReactiveFormsModule,
    NgbModule,
  ],
  providers: [HttpService,NgbActiveModal],
  bootstrap: [AppComponent]
})
export class AppModule { }
