import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { Globals } from "../globals";

@Injectable({
    providedIn: 'root'
})

export class ModifierCompteGuard implements CanActivate {

    constructor(private _router: Router) {}

    canActivate(): boolean{
        let jwt = Globals.decodeJwt();
        if(jwt['ModifierCompte'] === 'True'){
            return true;
        }
        this._router.navigate(['login']);
        return false;
    }
}