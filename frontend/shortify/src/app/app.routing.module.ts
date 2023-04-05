import { ShortUrlsContainerComponent } from './modules/url-shortener/short-urls-container/short-urls-container.component';
import { NgModule, inject } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LoginGuard } from './modules/auth/resources/guards/login.guard';
import { LoginComponent } from './modules/auth/login/login.component';
import { UrlRedirectionComponent } from './modules/url-shortener/url-redirection/url-redirection.component';
import { RegisterComponent } from './modules/auth/register/register.component';
const routes = [
    {
        path:'',
        //canActivate:[() => inject(LoginGuard).canActivate()],
        component: ShortUrlsContainerComponent,
    },
    {
        path:'login',
        component:LoginComponent,
    },
    {
        path:'register', component:RegisterComponent
    },
    {
        path: ':shortUrl', component:UrlRedirectionComponent
    },
]

@NgModule({
    imports:[
        RouterModule.forRoot(routes)
    ]
})
export class AppRoutingModule{}