import { ConnexionDTO } from '../DTO/ConnexionDTO';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { VariableGlobales } from 'src/app/url_api';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient : HttpClient) { }

  connect(connexionDTO : ConnexionDTO): Observable<string>
  {
    return this.httpClient.post<string>(VariableGlobales.apiURLLogin, connexionDTO);
  }

}
