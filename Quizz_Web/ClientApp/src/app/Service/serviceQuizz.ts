import { VariableGlobales } from "../url_api";

export class ServiceQuizz
{
  // * Retoune les details du quizz avec le code unique pa
  public static GetQuizzByCode(prmCode: string): Promise<Response>
  {
    return fetch(VariableGlobales.apiURLQuizz + prmCode, { method: "GET" })
  }

  // * Retourne la route de validation du Quizz 
  public static ValidateQuizz(prmCodeQuizz: string): Promise<Response>
  {
    
    return fetch(VariableGlobales.apiURLQuizz + prmCodeQuizz, { method: "GET" })
  }
}
