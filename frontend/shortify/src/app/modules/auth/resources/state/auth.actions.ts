import { createAction, props } from "@ngrx/store";
import { LoginUserModel } from "../models/loginUser.model";
import { AuthResultModel } from "../models/authResult.model";
import { UserModel } from "../models/userModel.model";
import { RegisterUser } from "../models/registerUser.model";


export const loginUser = createAction(
    '[Login component] login user',
    props<{request:LoginUserModel}>(),
)

export const authUserSuccess = createAction(
    '[Login component] login user success',
    props<{authResult:AuthResultModel}>(),
)

export const authUserFailure = createAction(
    '[Login component] login user failure',
    props<{errors:any}>(),
)

export const getUserSuccess = createAction(
    '[Login component] get user',
    props<{user:UserModel}>(),
)

export const loadCurrentUser = createAction(
    '[Login component load user]',
)

export const registerUser = createAction(
    '[Register component] register user',
    props<{model:RegisterUser}>(),
)

