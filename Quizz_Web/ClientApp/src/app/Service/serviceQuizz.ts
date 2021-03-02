import { VariableGlobales } from "../url_api";

export class ServiceQuizz
{
  // * Retoune les details du quizz avec le code unique pa
  public static GetQuizzByCode(prmCode: string): Promise<Response>
  {
    return fetch(VariableGlobales.apiURLQuizz + prmCode, { method: "GET" })
  }
}
