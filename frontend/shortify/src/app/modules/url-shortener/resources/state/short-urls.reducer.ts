import { createReducer, on } from '@ngrx/store';
import { ShortUrl } from './../models/shortUrl.model';
import { createShortUrl, createShortUrlFailure, createShortUrlSuccess, deleteShortUrlSuccess, editDescriptionSuccess, loadDescriptionSucess, loadUrlsFailure, loadUrlsSuccess } from './short-urls.actions';
import { Description } from '../models/description.model';


export interface State{
    shortUrls: ShortUrl[],
    errors:any,
    addingNewUrl:boolean,
    algorithmDescription:Description | null,
}

export const urlsFeatureKey ='short-urls-feature-key'
export const initialState:State= {
    shortUrls:[],
    errors:null,
    addingNewUrl:false,
    algorithmDescription:null,
}

export const reducer = createReducer(initialState,
    on(loadUrlsSuccess, (state,action) => {
        return {
            ...state,
            shortUrls:action.urls,
            errors:null,
        }
    }),
    on(loadUrlsFailure, (state,action) => {
        return {
            ...state,
            shortUrls:[],
            errors:action.errors,
        }
    }),
    on(createShortUrl, (state,action) => {
        return {
            ...state,
            addingNewUrl:true,
        }
    }),
    on(createShortUrlSuccess, (state,action) => {
        const newArray = [action.shortUrl, ...state.shortUrls];
        return {
            ...state,
            shortUrls:newArray,
            errors:null,
            addingNewUrl:false,
        }
    }),
    on(createShortUrlFailure, (state,action) => {
        return {
            ...state,
            errors:action.errors,
            addingNewUrl:false,
        }
    }),
    on(deleteShortUrlSuccess, (state,action) => {
        const index = state.shortUrls.findIndex(x => x.id == action.deletedId);
        const newArray = [...state.shortUrls];
        newArray.splice(index, 1);
        return {
            ...state,
            errors:null,
            shortUrls:newArray,
        }
    }),
    on(loadDescriptionSucess, (state,action) => {
        return {
            ...state,
            algorithmDescription:action.desc,
        }
    }),
    on(editDescriptionSuccess, (state,action)=>{
        const newDesc:Description ={
            description:action.newDescription,
        }
        
        return {
            ...state,
            algorithmDescription:newDesc,
        }
    })
)