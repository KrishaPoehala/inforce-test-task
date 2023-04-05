import { catchError, of } from 'rxjs';
import { map } from 'rxjs';
import { switchMap } from 'rxjs';
import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { createShortUrl, createShortUrlFailure, createShortUrlSuccess, deleteShortUrl, deleteShortUrlSuccess, editDescription, editDescriptionSuccess, loadDescription, loadDescriptionSucess, loadUrls, loadUrlsFailure, loadUrlsSuccess } from "./short-urls.actions";
import { ShortUrlsService } from '../services/shortUrls.service';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AppState } from 'src/app/store';
import { Store } from '@ngrx/store';



@Injectable()
export class ShortUrlsEffects{
    constructor(private actions:Actions, private http:ShortUrlsService,
        private modal:NgbModal,private store:Store<AppState>)
    {}

    loadUrls$ = createEffect(() => this.actions.pipe(
        ofType(loadUrls),
        switchMap(action => this.http.getAll().pipe(
            map(result => loadUrlsSuccess({urls:result})),
            catchError(errors => of(loadUrlsFailure({errors:errors}))),
        )
        )
    ))

    createShortUrl$ = createEffect(() => this.actions.pipe(
        ofType(createShortUrl),
        switchMap(action => this.http.createShortUrl(action.originalUrl).pipe(
            map(result =>{
                this.modal.dismissAll();
                return createShortUrlSuccess({shortUrl:result});
            }),
            catchError(errors => {
                this.store.dispatch(createShortUrlFailure({errors:errors}));
                return of(createShortUrlFailure({errors:[errors.error.message]}))
            })),
        ))
    )

    deleteShortUrl$ = createEffect(() => this.actions.pipe(
        ofType(deleteShortUrl),
        switchMap(action => this.http.deleteShortUrl(action.id).pipe(
            map(_ => deleteShortUrlSuccess({deletedId:action.id}))
        ))
    ))

    loadDescription$ = createEffect(() => this.actions.pipe(
        ofType(loadDescription),
        switchMap(action => this.http.getDescription().pipe(
            map(result => loadDescriptionSucess({desc:result}))
        ))
    ))

    editDescription$ = createEffect(() => this.actions.pipe(
        ofType(editDescription),
        switchMap(action => this.http.editDescription(action.newDescription).pipe(
            map(_ => {
                return editDescriptionSuccess({newDescription:action.newDescription});
            })
        ))
    ))
}