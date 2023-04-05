import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, firstValueFrom } from 'rxjs';
import { AppState } from 'src/app/store';
import { ShortUrl } from '../resources/models/shortUrl.model';
import { allUrlsSelector } from '../resources/state/short-urls.selectors';
import { loadUrls } from '../resources/state/short-urls.actions';

@Component({
  selector: 'app-url-redirection',
  templateUrl: './url-redirection.component.html',
  styleUrls: ['./url-redirection.component.css']
})
export class UrlRedirectionComponent implements OnInit {
  constructor(private route: ActivatedRoute,private store:Store<AppState>,private router:Router)
   { }

  
  shortUrls$!:Observable<ShortUrl[]>;
  async ngOnInit() {
    this.store.dispatch(loadUrls());
    this.shortUrls$ = this.store.select(allUrlsSelector);
    const shortUrl = this.route.snapshot.paramMap.get('shortUrl');
    console.log(shortUrl);

    this.shortUrls$.subscribe(result => {
      let url = result.find(x => x.shortenedUrl == shortUrl);
      if(url){
        //chrome blocks me to redirect from http://localhost to a new tab
        //window.open(url.originalUrl,'_blank')
        window.location.href = url.originalUrl;
        return;
      }

      this.router.navigateByUrl('');
    })
  }

}
