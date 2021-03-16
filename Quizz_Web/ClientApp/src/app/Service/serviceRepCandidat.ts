import { Globals } from '../globals';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from "rxjs";
import { ReponseCandidatDTO } from "../DTO/ReponseCandidatDTO";
import { VariableGlobales } from "../url_api";

@Injectable({
  providedIn: 'root'
})

export class serviceRepCandidat
{



  // *Poste la réponse du candidat
  public static PostReponse(prmDTO: ReponseCandidatDTO): Promise<Response>
  {
    console.log("Envoi de la réponse...")
    console.log(prmDTO)

    const requestHeaders: HeadersInit = new Headers();
    requestHeaders.set('Content-Type', 'application/json');
    requestHeaders.set('Authorization', Globals.getJwt());

    return fetch(VariableGlobales.apiURLReponseCandidat,
      {
        method: "POST",
        headers: requestHeaders,
        body: JSON.stringify(prmDTO)
      })

  }


}
