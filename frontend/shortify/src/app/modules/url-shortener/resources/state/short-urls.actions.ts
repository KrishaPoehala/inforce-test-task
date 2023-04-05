import { createAction, props } from "@ngrx/store";
import { ShortUrl } from "../models/shortUrl.model";
import { Description } from "../models/description.model";

export const loadUrls = createAction(
    '[Short urls component] load urls',
)

export const loadUrlsSuccess = createAction(
    '[Short urls component] load urls success',
    props<{urls:ShortUrl[]}>(),
)

export const loadUrlsFailure = createAction(
    '[Short urls component] load urls failure',
    props<{errors:any}>(),
)

export const createShortUrl = createAction(
    '[Add short urls component] create new',
    props<{originalUrl:string}>(),
)

export const createShortUrlSuccess = createAction(
    '[Add short urls component] create success',
    props<{shortUrl:ShortUrl}>(),
)

export const createShortUrlFailure = createAction(
    '[Add short urls component] create failure',
    props<{errors:any}>(),
)

export const deleteShortUrl = createAction(
    '[Short url component] delete url',
    props<{id:string}>(),
)

export const deleteShortUrlSuccess = createAction(
    '[Short url component] delete url success',
    props<{deletedId:string}>()
)

export const loadDescription = createAction(
    '[Short url component] load desc',
)

export const loadDescriptionSucess = createAction(
    '[Short url component] load desc success',
    props<{desc:Description}>(),
)

export const editDescription = createAction(
    '[Description component] edit',
    props<{newDescription:string}>(),
)

export const editDescriptionSuccess = createAction(
    '[Description component] edit success',
    props<{newDescription:string}>(),
)