import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";


@Injectable()
export class HttpService{
    
    constructor(private http: HttpClient){
    }

    public get<T>(url:string){
        console.log(environment.api + '/' + url);
        return this.http.get<T>(environment.api + '/' + url);
    }

    public post<T>(url:string, model:any){
        return this.http.post<T>(environment.api + '/' + url, model);
    }

    public delete(url:string){
        return this.http.delete(environment.api + '/' + url);
    }

    public put(url:string,model:any){
        return this.http.put(environment.api + '/' + url, model);
    }
    
}