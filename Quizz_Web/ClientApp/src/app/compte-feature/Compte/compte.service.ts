import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Compte } from './compte.model';
import { Globals } from 'src/app/globals';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PermissionNameDTO } from '../../DTO/permissionNameDTO';
import { VariableGlobales } from 'src/app/url_api';

@Injectable({
  providedIn: 'root'
})
export class CompteService
{

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<Compte[]>
  {

    const headerDictionnary = {
      'Authorization': Globals.getJwt()
    }

    const requestOptions = {
      headers: new HttpHeaders(headerDictionnary)
    }

    return this.httpClient.get<Compte[]>(VariableGlobales.apiURLCompte, requestOptions);
  }



  create(compte: Compte): Observable<Compte>
  {
    return this.httpClient.post<Compte>(VariableGlobales.apiURLCompte, compte);
  }



  delete(compte: Compte)
  {
    let deleteRequest: string = VariableGlobales.apiURLCompte;
    deleteRequest += `${compte.id}`;

    console.log(deleteRequest);

    const headerDictionnary = {
      'Authorization': Globals.getJwt()
    }

    const requestOptions = {
      headers: new HttpHeaders(headerDictionnary)
    }

    console.log(headerDictionnary);

    return this.httpClient.delete(deleteRequest, requestOptions);

  }



  modifyPermission(compte: Compte, permissionNameDTO: PermissionNameDTO): Observable<PermissionNameDTO>
  {
    return this.httpClient.put<PermissionNameDTO>(VariableGlobales.apiURLCompte + compte.id + "/permission", permissionNameDTO);
  }
}
