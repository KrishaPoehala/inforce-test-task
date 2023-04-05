
import * as fromRouter from '@ngrx/router-store';
import { ActionReducer, ActionReducerMap, MetaReducer } from '@ngrx/store';
import { environment } from 'src/environments/environment';
import * as fromAuth from '../modules/auth/resources/state/auth.reducer'
import * as fromShortUrls from '../modules/url-shortener/resources/state/short-urls.reducer'
export interface AppState{
    router:fromRouter.RouterReducerState,
    [fromAuth.authFeatureKey]: fromAuth.State,
    [fromShortUrls.urlsFeatureKey]: fromShortUrls.State,
}

const routerKey = 'router';
export const reducers:ActionReducerMap<AppState> = {
    [routerKey]: fromRouter.routerReducer,
    [fromAuth.authFeatureKey]: fromAuth.reducer,
    [fromShortUrls.urlsFeatureKey]: fromShortUrls.reducer,
};

export function debug(reducer: ActionReducer<any>): ActionReducer<any> {
    return function (state, action) {
       console.log('state', state);
       console.log('action', action);

      return reducer(state, action);
    };
}

export const metaReducers: MetaReducer<AppState>[] = !environment.production
  ? [debug]
  : [];