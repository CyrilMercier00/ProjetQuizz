import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { VariableGlobales } from 'src/app/url_api';
import { ConnexionDTO } from '../DTO/ConnexionDTO';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient : HttpClient) { }

  connect(connexionDTO : ConnexionDTO): Observable<ConnexionDTO> {
    return this.httpClient.post<ConnexionDTO>(VariableGlobales.apiURLLogin, connexionDTO);
  }
}
