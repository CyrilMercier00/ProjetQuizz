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
    let jwt = Globals.decodeJwt();

    const requestHeaders: HeadersInit = new Headers();
    requestHeaders.set('Content-Type', 'application/json');
    requestHeaders.set('Authorization', Globals.getJwt());

    return fetch(VariableGlobales.apiURLCompte + "kko/" + prmCode + "/" + jwt['id'], { method: "GET", headers: requestHeaders })

  }
}
