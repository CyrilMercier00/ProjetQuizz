import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { VariableGlobales } from 'src/app/url_api';
import { environment } from 'src/environments/environment';
import { getBaseUrl } from 'src/main';
import { Compte } from './compte.model';

@Injectable({
  providedIn: 'root'
})
export class CompteService {

  constructor(private httpClient : HttpClient) { }

  getAll(): Observable<Compte[]>{
    return this.httpClient.get<Compte[]>(VariableGlobales.apiURLCompte);
  }
}
