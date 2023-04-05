import { UserModel } from "src/app/modules/auth/resources/models/userModel.model";


export interface ShortUrl{
    id:string,
    originalUrl:string,
    shortenedUrl:string,
    createdBy:UserModel,
}