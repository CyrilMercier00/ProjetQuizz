import { DTOQuizz } from "../DTO/dto-quizz";
import { Globals } from "../globals";
import { Injectable } from '@angular/core';
import { VariableGlobales } from "../url_api";

@Injectable({
  providedIn: 'root'
})

export class ServiceQuizz
{
  // * Retoune les details du quizz avec le code unique pa
  public static GetQuizzByCode(prmCode: string): Promise<Response>
  {
    const requestHeaders: HeadersInit = new Headers();
    requestHeaders.set('Content-Type', 'application/json');
    requestHeaders.set('Authorization', Globals.getJwt());

    return fetch(VariableGlobales.apiURLQuizz + prmCode, { method: "GET", headers: requestHeaders });

  }



  // * Retoune les details du quizz avec le code
  public static UpdateQuizz(prmCode: string): Promise<Response>
  {
    const requestHeaders: HeadersInit = new Headers();
    requestHeaders.set('Content-Type', 'application/json');
    requestHeaders.set('Authorization', Globals.getJwt());

    this.GetQuizzByCode(prmCode);

    return fetch(VariableGlobales.apiURLQuizz + prmCode, { method: "PUT", headers: requestHeaders })
  }



  // * Retourne la route de validation du Quizz
  public static ValidateQuizz(prmCodeQuizz: string): Promise<Response>
  {
    let jwt = Globals.decodeJwt();

    const requestHeaders: HeadersInit = new Headers();
    requestHeaders.set('Content-Type', 'application/json');
    requestHeaders.set('Authorization', Globals.getJwt());

    return fetch(VariableGlobales.apiURLFinQuizz + prmCodeQuizz + "/" + jwt['id']+ "/" +"fin", { method: "GET", headers: requestHeaders })
  }



  public static InsertQuizz(prmDTO: DTOQuizz): Promise<Response>
  {
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
