import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { VariableGlobales } from 'src/app/url_api';
import { Compte } from './compte.model';

@Injectable({
  providedIn: 'root'
})
export class CompteService {

  constructor(private httpClient : HttpClient) { }

  getAll(): Observable<Compte[]>{
    return this.httpClient.get<Compte[]>(VariableGlobales.apiURLCompte);
  }

  create(compte : Compte) : Observable<Compte>{
    return this.httpClient.post<Compte>(VariableGlobales.apiURLCompte, compte);
  }
}
