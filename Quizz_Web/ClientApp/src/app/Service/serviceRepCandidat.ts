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

    return fetch(
      VariableGlobales.apiURLQuizz,
      {
        method: "POST",
        headers:
        {
          'Accept': 'application/json',
          'Content-Type': 'application/json',
          'Authorization': Globals.getJwt()
        },
        body: JSON.stringify(prmDTO)
      }
    )
  }


}
