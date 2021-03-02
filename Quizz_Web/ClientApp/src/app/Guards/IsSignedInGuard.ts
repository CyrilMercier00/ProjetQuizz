import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { Globals } from "../globals";

@Injectable({
    providedIn: 'root'
})

export class IsSignedInGuard implements CanActivate {

    constructor(private _router: Router) {}

    canActivate(): boolean{
        let jwt = Globals.decodeJwt();
        if(jwt == ""){
            return false;
        }
        this._router.navigate(['login']);
        return true;
    }
}