import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { Globals } from "../globals";

@Injectable({
    providedIn: 'root'
})

export class AjouterQuestGuard implements CanActivate {

    constructor(private _router: Router) {}

    canActivate(): boolean{
        if(!Globals.isLoggedOut())
        {
            let jwt = Globals.decodeJwt();
        
            if(jwt['AjouterQuest'] === 'True'){
                return true;
            }
        }
        
        return false;
    }
}