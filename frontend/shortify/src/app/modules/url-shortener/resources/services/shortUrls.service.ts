import { editDescription } from './../state/short-urls.actions';
import { Inject, Injectable } from "@angular/core";
import { HttpService } from "src/app/core/services/http.service";
import { ShortUrl } from "../models/shortUrl.model";
import { Description } from "../models/description.model";


@Injectable({
    providedIn:'root',
})
export class ShortUrlsService{
    constructor(private http:HttpService)
    {}

    getAll(){
        return this.http.get<ShortUrl[]>('urls/all');
    }

    createShortUrl(originalUrl:string){
        const model = {
            originalUrl:originalUrl,
        }

        return this.http.post<ShortUrl>('urls/create', model);
    }

    deleteShortUrl(id:string){
        return this.http.delete(`urls/delete/${id}`);
    }

    getDescription(){
        return this.http.get<Description>('description');
    }

    editDescription(newDescription:string){
        const model = {
            newDescription:newDescription,
        }
        return this.http.put('description/edit',model);
    }
}