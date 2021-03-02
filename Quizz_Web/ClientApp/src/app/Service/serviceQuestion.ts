import { VariableGlobales } from "../url_api";

export class ServiceQuestions
{

  // * Retourne la liste des questions du quizz avec l'id passé en param
  public static GetQuestionsByIDQuizz(prmPKQuizz: number): Promise<Response>
  {
    return fetch(VariableGlobales.apiURLQuestion + prmPKQuizz, { method: "GET" })
  }

  public static GetQuestionsByCodeQuizz(prmCodeQuizz: string): Promise<Response>
  {
    return fetch(VariableGlobales.apiURLQuestion + "code/" + prmCodeQuizz, { method: "GET" })
  }

}
