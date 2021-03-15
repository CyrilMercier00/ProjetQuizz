import { VariableGlobales } from "../url_api";
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from "rxjs";
import { DTOQuizz } from "../DTO/dto-quizz";
import { Globals } from "../globals";

@Injectable({
  providedIn: 'root'
})

export class ServiceQuizz
{
  // * Retoune les details du quizz avec le code unique pa
  public static GetQuizzByCode(prmCode: string): Promise<Response>
  {
    return fetch(VariableGlobales.apiURLQuizz + prmCode, { method: "GET" })
  }

  // * Retoune les details du quizz avec le code unique pa
  public static UpdateQuizz(prmCode: string): Promise<Response>
  {
    this.GetQuizzByCode(prmCode);
    return fetch(VariableGlobales.apiURLQuizz + prmCode, { method: "PUT" })
  }

  
  
  // * Retourne la route de validation du Quizz 
  public static ValidateQuizz(prmCodeQuizz: string): Promise<Response>
  {
    let jwt = Globals.decodeJwt();    
    return fetch(VariableGlobales.apiURLFinQuizz+ prmCodeQuizz+ "/" + jwt['id'],{ method: "GET" })
  }
 
}
