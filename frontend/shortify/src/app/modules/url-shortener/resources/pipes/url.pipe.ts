import { DOCUMENT } from "@angular/common";
import { Inject, Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name:'urlPipe'
})
export class UrlPipe implements PipeTransform{
    constructor(@Inject(DOCUMENT) private document: Document) { }
    transform(value: string, ...args: any[]) {
        return this.document.location.origin+ '/' + value;
    }
}