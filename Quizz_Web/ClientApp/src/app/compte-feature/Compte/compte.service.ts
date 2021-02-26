import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { VariableGlobales } from 'src/app/url_api';
import { Compte } from './compte.model';
import { PermissionNameDTO } from '../../DTO/permissionNameDTO';

@Injectable({
  providedIn: 'root'
})
export class CompteService {

  constructor(private httpClient : HttpClient) { }

  getAll(): Observable<Compte[]>{
    return this.httpClient.get<Compte[]>(VariableGlobales.apiURLCompte);
  }

  create(compte : Compte) : Observable<Compte>{
    console.log(compte);
    return this.httpClient.post<Compte>(VariableGlobales.apiURLCompte, compte);
  }

  delete(compte: Compte){
    let deleteRequest: string =  VariableGlobales.apiURLCompte;
    deleteRequest += `${compte.id}`;
    return this.httpClient.delete(deleteRequest);
  }

  modifyPermission(compte: Compte, permissionNameDTO : PermissionNameDTO) : Observable<PermissionNameDTO>{
    let idCompte = compte.id;
    return this.httpClient.put<PermissionNameDTO>(VariableGlobales.apiURLCompte + idCompte + "/permission", permissionNameDTO);
  }
}
