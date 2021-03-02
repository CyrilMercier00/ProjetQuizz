import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { Globals } from "../globals";

@Injectable({
    providedIn: 'root'
})

export class GenererQuizzGuard implements CanActivate {

    constructor(private _router: Router) {}

    canActivate(): boolean{
        let jwt = Globals.decodeJwt();
        if(jwt['GenererQuizz'] === 'True'){
            return true;
        }
        this._router.navigate(['login']);
        return false;
    }
}