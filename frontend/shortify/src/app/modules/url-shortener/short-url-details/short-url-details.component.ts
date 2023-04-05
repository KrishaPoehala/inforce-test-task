import { ShortUrl } from './../resources/models/shortUrl.model';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-short-url-details',
  templateUrl: './short-url-details.component.html',
  styleUrls: ['./short-url-details.component.css']
})
export class ShortUrlDetailsComponent {
  @Input() shortUrl!:ShortUrl
}
