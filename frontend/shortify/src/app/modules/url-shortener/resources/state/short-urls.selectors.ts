import { createFeatureSelector, createSelector } from "@ngrx/store";
import * as fromShortUrls from '../state/short-urls.reducer'

export const urlsFeatureSelector = createFeatureSelector<fromShortUrls.State>(
    fromShortUrls.urlsFeatureKey
);

export const allUrlsSelector = createSelector(
    urlsFeatureSelector,
    (state) => state.shortUrls
)

export const errorsSelector = createSelector(
    urlsFeatureSelector,
    (state) => state.errors
)

export const addingNewUrlSelector = createSelector(
    urlsFeatureSelector,
    (state) => state.addingNewUrl
)

export const descriptionSelector = createSelector(
    urlsFeatureSelector,
    (state) => state.algorithmDescription
)

