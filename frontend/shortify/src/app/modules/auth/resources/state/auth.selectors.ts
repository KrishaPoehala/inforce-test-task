import { createFeatureSelector, createSelector } from "@ngrx/store";
import * as fromAuth from '../state/auth.reducer'
import { Roles } from "../enums/roles.enum";

const authSelectorFeatureSelector = createFeatureSelector<fromAuth.State>(
    fromAuth.authFeatureKey
);

export const currentUserSelector = createSelector(
    authSelectorFeatureSelector,
    (state) => state.user
)

export const isAdmin = createSelector(
    authSelectorFeatureSelector,
    (state) => state.user?.role === Roles.Admin
)