import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { VariableGlobales } from 'src/app/url_api';
import { PermissionNameDTO } from '../DTO/permissionNameDTO';
import { Globals } from '../globals';

@Injectable({
  providedIn: 'root'
})
export class PermissionService {

  constructor(private httpClient : HttpClient) { }

  getAll(): Observable<PermissionNameDTO[]> {
    return this.httpClient.get<PermissionNameDTO[]>(VariableGlobales.apiURLPermission + "names/");
  }

  verifyPermission(permissionName : string) : boolean {
    let obj = Globals.decodeJwt();

    if(obj[permissionName] === 'True'){
      return true;
    }
    return false;
  }
}
