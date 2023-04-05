import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShortUrlsContainerComponent } from './short-urls-container/short-urls-container.component';
import { EffectsModule } from '@ngrx/effects';
import { ShortUrlsEffects } from './resources/state/short-urls.effects';
import { ShortUrlsService } from './resources/services/shortUrls.service';
import { UrlPipe } from './resources/pipes/url.pipe';
import { AddShortUrlComponent } from './add-short-url/add-short-url.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbActiveModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MatIconModule } from '@angular/material/icon';
import { UrlRedirectionComponent } from './url-redirection/url-redirection.component';
import { AlgorithmDescriptionComponent } from './algorithm-description/algorithm-description.component';
import { ShortUrlDetailsComponent } from './short-url-details/short-url-details.component';

@NgModule({
  declarations: [
    ShortUrlsContainerComponent,
    UrlPipe,
    AddShortUrlComponent,
    UrlRedirectionComponent,
    AlgorithmDescriptionComponent,
    ShortUrlDetailsComponent,
  ],
  imports: [
    MatIconModule,
    NgbModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    EffectsModule.forFeature([ShortUrlsEffects])
  ],
  providers:[ShortUrlsService,NgbActiveModal]
})
export class UrlShortenerModule { }
