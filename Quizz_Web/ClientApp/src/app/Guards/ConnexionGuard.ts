import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { Globals } from "../globals";

@Injectable({
    providedIn: 'root'
})

export class ConnexionGuard implements CanActivate {

    constructor(private _router: Router) {}

    canActivate(): boolean{
        console.log(Globals.isLoggedIn());
        return Globals.isLoggedIn();
    }
}