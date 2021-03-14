import { VariableGlobales } from "../url_api";
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from "rxjs";
import { ReponseCandidatDTO } from "../DTO/ReponseCandidatDTO";

@Injectable({
  providedIn: 'root'
})

export class serviceRepCandidat
{
  // * Retoune les details du quizz avec le code unique pa
  public static PostReponse(prmDTO: ReponseCandidatDTO): Promise<Response>
  {
    return fetch(
      VariableGlobales.apiURLQuizz,
      {
        method: "POST",
        headers:
        {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(prmDTO)
      }
    )
  }


}
