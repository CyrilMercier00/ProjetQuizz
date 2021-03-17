import { ComptePersonnelDTO } from '../DTO/ComptePersonnelDTO';
import { Globals } from '../globals';
import { Injectable } from '@angular/core';
import { VariableGlobales } from '../url_api';

@Injectable({
  providedIn: 'root'
})
export class CompteService
{

  constructor() { }

  public static GetCompteLinkedToCode(prmCode: string): Promise<Response>
  {
    let jwt: string;
    if(Globals.isLoggedIn()){
      jwt = Globals.decodeJwt();
    } else{
      jwt = '';
    }
    

    const requestHeaders: HeadersInit = new Headers();
    requestHeaders.set('Content-Type', 'application/json');
    requestHeaders.set('Authorization', Globals.getJwt());
    return fetch(VariableGlobales.apiURLCompte + "kko/" + prmCode + "/deconnecte", { method: "GET", headers: requestHeaders })

  }
}
