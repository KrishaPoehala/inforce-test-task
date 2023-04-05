import { createReducer, on } from "@ngrx/store";
import { UserModel } from "../models/userModel.model";
import { getUserSuccess } from "./auth.actions";


export interface State{
    user:UserModel|null,
    isLoggedIn:boolean,
}

export const initialState:State ={
    user:null,
    isLoggedIn:false,
}

export const authFeatureKey = 'auth-feature-key'

export const reducer = createReducer(initialState,
    on(getUserSuccess, (state,action) => {
        return {
            ...state,
            user:action.user,
            isLoggedIn:true,
        }
    })
);